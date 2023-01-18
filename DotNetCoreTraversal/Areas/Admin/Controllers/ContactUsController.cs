using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _cus;

        public ContactUsController(IContactUsService cus)
        {
            _cus = cus;
        }

        public IActionResult ChangeContact(int id)
        {
            _cus.ChangeContactState(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var values = _cus.ActiveContactList();
            return View(values);
        }

        public IActionResult ContactDetails(int id)
        {
            var value = _cus.FindEntityByID(id);
            return View(value);
        }
    }
}
