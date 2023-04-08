using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiSQL.DAL;
using SignalRApiSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRApiSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _vs;

        public VisitorController(VisitorService vs)
        {
            _vs = vs;
        }

        [HttpGet]
        public IActionResult CreateVisitor()
        {
            Random rand = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity city in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = city,
                        CityVisitCount = rand.Next(100, 2000),
                        VisitDate = DateTime.Now.AddDays(x)
                    };
                    _vs.SaveVisitor(newVisitor).Wait();
                    Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçi eklemesi başarılı.");
        }
    }
}
