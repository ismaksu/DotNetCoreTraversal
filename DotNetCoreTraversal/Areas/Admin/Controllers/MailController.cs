using DotNetCoreTraversal.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class MailController : Controller
    {
        public IActionResult MailOperations()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mail)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(mail.Name, "ismtraversalbusiness@gmail.com");

            message.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("Kullanıcı", mail.ReceiverMail);
            message.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mail.Body;
            message.Body = bodyBuilder.ToMessageBody();

            message.Subject = mail.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ismtraversalbusiness@gmail.com", "czhdpgchmppaiyfz");
            client.Send(message);
            client.Disconnect(true);

            return View();
        }
    }
}
