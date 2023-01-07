using BusinessLayer.Abstract.AbstractUow;
using DotNetCoreTraversal.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel accountModel)
        {
            var valueSender = _accountService.TGetByID(accountModel.SenderID);
            var valueReceiver = _accountService.TGetByID(accountModel.ReceiverID);

            valueSender.Balance -= accountModel.Amount;
            valueReceiver.Balance += accountModel.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            _accountService.MultiUpdate(modifiedAccounts);

            return RedirectToAction("Index");
        }
    }
}
