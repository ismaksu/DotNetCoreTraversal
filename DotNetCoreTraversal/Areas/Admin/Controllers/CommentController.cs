using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _cms;
        private readonly IDestinationService _ds;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService cms, IDestinationService ds, UserManager<AppUser> userManager)
        {
            _cms = cms;
            _ds = ds;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _cms.ListCommentWithDestination();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditComment(int id)
        {
            List<SelectListItem> sliValues = (from x in _ds.ListEntities()
                                           select new SelectListItem
                                           {
                                               Text = x.CityName,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();

            ViewBag.sli = sliValues;

            var comment = _cms.GetCommentWithDestination(id);
            return View(comment);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditComment(Comment comment)
        {
            var user = await _userManager.FindByIdAsync(comment.AppUserId.ToString());
            var nameSurname = user.Name + " " + user.Surname;
            comment.CommentAuthor = nameSurname;
            _cms.UpdateEntity(comment);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _cms.FindEntityByID(id);
            _cms.DeleteEntity(comment);
            return RedirectToAction("Index");
        }
    }
}
