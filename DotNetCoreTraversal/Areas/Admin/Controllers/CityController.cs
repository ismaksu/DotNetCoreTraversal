using BusinessLayer.Abstract;
using DotNetCoreTraversal.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CityController : Controller
    {
        private readonly IDestinationService _ds;

        public CityController(IDestinationService ds)
        {
            _ds = ds;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCities = JsonConvert.SerializeObject(_ds.ListEntities());
            return Json(jsonCities);
        }

        public IActionResult GetByID(int DestinationID)
        {
            var destination = _ds.FindEntityByID(DestinationID);
            var jsonDestination = JsonConvert.SerializeObject(destination);
            return Json(jsonDestination);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination p)
        {
            p.Status = true;
            _ds.AddEntity(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _ds.FindEntityByID(id);
            _ds.DeleteEntity(values);
            return NoContent();
        }

        public IActionResult UpdateCity (Destination p)
        {
            _ds.UpdateEntity(p);
            var jsonValues = JsonConvert.SerializeObject(p);
            return Json(jsonValues);

        }
    }
}
