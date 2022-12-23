using BusinessLayer.Abstract;
using System.Collections.Generic;
using DotNetCoreTraversal.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using System;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AnnouncementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementService _ans;

        public AnnouncementController(IAnnouncementService ans, IMapper mapper)
        {
            _mapper = mapper;
            _ans = ans;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_ans.ListEntities());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO p)
        {
            if (ModelState.IsValid)
            {
                _ans.AddEntity(new Announcement()
                {
                    Content = p.Content,
                    Title = p.Title,
                    Date = DateTime.Now
                });

                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _ans.FindEntityByID(id);
            _ans.DeleteEntity(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_ans.FindEntityByID(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO p)
        {
            if (ModelState.IsValid)
            {
                _ans.UpdateEntity(new Announcement
                {
                    AnnouncementID = p.AnnouncementID,
                    Title = p.Title,
                    Content = p.Content,
                    Date = p.Date
                });
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
