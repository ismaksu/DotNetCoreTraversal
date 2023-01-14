using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DotNetCoreTraversal.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _dsm;

        public DestinationController(IDestinationService dsm)
        {
            _dsm = dsm;
        }

        public IActionResult Index()
        {
            var values = _dsm.ListDestination();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDestination(DestinationViewModel p)
        {
            p.Status = true;
            var resource = Directory.GetCurrentDirectory();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/cityImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                p.ImageURL = "/cityImages/" + imageName;
                await p.Image.CopyToAsync(stream);
            }
            if (p.Image1 != null)
            {
                var extension = Path.GetExtension(p.Image1.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/cityImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                p.Image1URL = "/cityImages/" + imageName;
                await p.Image1.CopyToAsync(stream);
            }
            if (p.CoverImage != null)
            {
                var extension = Path.GetExtension(p.CoverImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/cityImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                p.CoverImageURL = "/cityImages/" + imageName;
                await p.CoverImage.CopyToAsync(stream);
            }

            Destination destination = new Destination()
            {
                CityName = p.City,
                DayNight = p.DayNight,
                Price = p.Price,
                Image = p.ImageURL,
                Description = p.Description,
                Capacity = p.Capacity,
                Status = p.Status,
                CoverImage = p.CoverImageURL,
                Details1 = p.Details1,
                Details2 = p.Details2,
                Image1 = p.Image1URL
            };

            _dsm.AddEntity(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var destination = _dsm.FindEntityByID(id);
            _dsm.DeleteEntity(destination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var destination = _dsm.FindEntityByID(id);

            DestinationViewModel model = new DestinationViewModel();
            model.DestinationID = destination.DestinationID;
            model.City = destination.CityName;
            model.DayNight = destination.DayNight;
            model.Price = destination.Price;
            model.ImageURL = destination.Image;
            model.Description = destination.Description;
            model.Capacity = destination.Capacity;
            model.Status = destination.Status;
            model.CoverImageURL = destination.CoverImage;
            model.Details1 = destination.Details1;
            model.Details2 = destination.Details2;
            model.Image1URL = destination.Image1;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDestination(DestinationViewModel p)
        {
            var resource = Directory.GetCurrentDirectory();

            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/cityImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                p.ImageURL = "/cityImages/" + imageName;
                await p.Image.CopyToAsync(stream);
            }
            if (p.Image1 != null)
            {
                var extension = Path.GetExtension(p.Image1.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/cityImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                p.Image1URL = "/cityImages/" + imageName;
                await p.Image1.CopyToAsync(stream);
            }
            if (p.CoverImage != null)
            {
                var extension = Path.GetExtension(p.CoverImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/cityImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                p.CoverImageURL = "/cityImages/" + imageName;
                await p.CoverImage.CopyToAsync(stream);
            }

            Destination destination = new Destination()
            {
                DestinationID = p.DestinationID,
                CityName = p.City,
                DayNight = p.DayNight,
                Price = p.Price,
                Image = p.ImageURL,
                Description = p.Description,
                Capacity = p.Capacity,
                Status = p.Status,
                CoverImage = p.CoverImageURL,
                Details1 = p.Details1,
                Details2 = p.Details2,
                Image1 = p.Image1URL
            };
            _dsm.UpdateEntity(destination);
            return RedirectToAction("Index");
        }
    }
}
