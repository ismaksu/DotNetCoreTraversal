using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _cms;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _cms = commentService;
        }

        [HttpGet]
        public PartialViewResult CommentAdd()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CommentAdd(Comment p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            p.CommentDate = DateTime.Now;
            p.CommentStat = true;
            p.AppUserId = user.Id;
            p.CommentAuthor = user.UserName;

            _cms.AddEntity(p);
            return ViewComponent("CommentList", new { id = p.DestinationID });
        }

        [HttpPost]
        public IActionResult CommentDelete(int id)
        {
            var comment = _cms.FindEntityByID(id);
            int destinationId = comment.DestinationID;
            _cms.DeleteEntity(comment);
            return ViewComponent("CommentList", new { id = destinationId });
        }
    }
}
