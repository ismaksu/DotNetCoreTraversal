using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
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
        public IActionResult Index(SendMessageDto contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddEntity(new ContactUs()
                {
                    MessageBody = contact.MessageBody,
                    Subject = contact.Subject,
                    Name = contact.Name,
                    Mail = contact.Mail,
                    MessageDate = DateTime.Now,
                    Status = true
                });
                return RedirectToAction("Index", "Default");
            }
            return View(contact);
        }
    }
}
