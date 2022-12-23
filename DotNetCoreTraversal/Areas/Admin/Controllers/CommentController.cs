using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _cms;

        public CommentController(ICommentService cms)
        {
            _cms = cms;
        }

        public IActionResult Index()
        {
            var values = _cms.ListCommentWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _cms.FindEntityByID(id);
            _cms.DeleteEntity(comment);
            return RedirectToAction("Index");
        }
    }
}
