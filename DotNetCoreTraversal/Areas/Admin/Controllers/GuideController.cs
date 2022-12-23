using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using DotNetCoreTraversal.Areas.Admin.Models;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using FluentValidation;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _gs;

        public GuideController(IGuideService gs)
        {
            _gs = gs;
        }

        public IActionResult ChangeStatGuide(int id)
        {
            _gs.ChangeGuideStat(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var values = _gs.ListEntities();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(GuideAddViewModel p)
        {
            Guide guide = new Guide();

            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                guide.Image = imageName;
            }

            guide.Name = p.Name;
            guide.Description = p.Description;
            guide.TwitterUrl = p.TwitterUrl;
            guide.InstagramUrl = p.InstagramUrl;
            guide.Status = true;

            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                _gs.AddEntity(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult EditGuide(int id = 1)
        {
            var guide = _gs.FindEntityByID(id);
            GuideAddViewModel guideModel = new GuideAddViewModel();
            guideModel.ID = guide.GuideID;
            guideModel.Stat = guide.Status;
            guideModel.Name = guide.Name;
            guideModel.Description = guide.Description;
            guideModel.ImageURL = guide.Image;
            guideModel.TwitterUrl = guide.TwitterUrl;
            guideModel.InstagramUrl = guide.InstagramUrl;
            return View(guideModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditGuide(GuideAddViewModel p)
        {
            Guide guide = new Guide();

            if (p.ImageURL != null)
            {
                guide.Image = p.ImageURL;
                if (p.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(p.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/userImages/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await p.Image.CopyToAsync(stream);
                    guide.Image = imageName;
                }
                
            }

            guide.Name = p.Name;
            guide.GuideID = p.ID;
            guide.Status = p.Stat;
            guide.Description = p.Description;
            guide.TwitterUrl = p.TwitterUrl;
            guide.InstagramUrl = p.InstagramUrl;

            _gs.UpdateEntity(guide);
            return RedirectToAction("Index");
        }
    }
}
