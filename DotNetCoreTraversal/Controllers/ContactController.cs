using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactService;

        public ContactController(IContactUsService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Index(ContactUs contact)
        {
            contact.MessageDate = DateTime.Now;
            contact.Status = true;
            _contactService.AddEntity(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
