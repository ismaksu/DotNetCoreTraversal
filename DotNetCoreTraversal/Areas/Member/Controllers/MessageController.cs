using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
