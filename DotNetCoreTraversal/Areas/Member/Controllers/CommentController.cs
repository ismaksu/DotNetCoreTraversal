using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]/{id?}")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var values = _commentService.ListCommentByUser(userId);
			return View(values);
		}
	}
}
