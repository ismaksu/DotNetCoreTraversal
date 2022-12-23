﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ReservationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDAL());
        ReservationManager rm = new ReservationManager(new EFReservationDAL());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> CurrentReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = rm.GetAcceptedReservation(user.Id);
            return View(values);
        }

        public async Task<IActionResult> OldReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;
            var values = rm.GetPreviousReservation(userId);
            return View(values);
        }

        public async Task<IActionResult> ApprovalReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;
            var values = rm.GetApprovalReservation(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in dm.ListEntities()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            p.ReservationStat = "Rezervasyon Onay Bekliyor..";
            p.AppUserId = userId;
            rm.AddEntity(p);
            return RedirectToAction("CurrentReservations", "Reservation", new { area = "Member" });
        }
    }
}
