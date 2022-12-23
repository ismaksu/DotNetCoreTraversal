using DotNetCoreTraversalAPI.DAL.Context;
using DotNetCoreTraversalAPI.DAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCoreTraversalAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using(var c = new VisitorContext())
            {
                var values = c.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using(var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using(var c = new VisitorContext())
            {
                c.Add(visitor);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    c.Remove(values);
                    c.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult VisitorUpdate(Visitor visitor)
        {
            using(var c = new VisitorContext())
            {
                var values = c.Find<Visitor>(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.City = visitor.City;
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    values.Mail = visitor.Mail;

                    c.Update(values);
                    c.SaveChanges();

                    return Ok(values);
                }
            }
        }
    }
}
