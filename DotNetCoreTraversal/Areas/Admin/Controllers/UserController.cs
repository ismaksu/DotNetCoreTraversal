using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly IAppUserService _aus;
        private readonly IReservationService _rs;

        public UserController(IAppUserService aus, IReservationService rs)
        {
            _aus = aus;
            _rs = rs;
        }

        public IActionResult Index()
        {
            var values = _aus.ListEntities();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var user = _aus.FindEntityByID(id);
            _aus.DeleteEntity(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _aus.FindEntityByID(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult EditUser(AppUser user)
        {
            _aus.UpdateEntity(user);
            return RedirectToAction("Index");
        }

        public IActionResult ReservationHistoryUser(int id)
        {
            var values = _rs.GetPreviousReservation(id);
            return View(values);
        }
    }
}
