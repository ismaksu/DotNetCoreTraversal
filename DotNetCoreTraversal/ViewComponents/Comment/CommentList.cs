using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.Comment
{
    public class CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Count = _commentService.ListCommentsByDestination(id).Count;
            ViewBag.userName = User.Identity.Name;
            var values = _commentService.ListCommentsByDestination(id);
            return View(values);
        }
    }
}
