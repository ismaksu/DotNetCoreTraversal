using DotNetCoreTraversal.Models;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, false);
                if (result.Succeeded)
                {
                    //Kullanıcı eğer authorize olmadan bir sayfaya girip oradan logine yönlendi ise login işlemi başarılı olduktan
                    //sonra kaldığı sayfaya devam etmesini sağlayacak kod.
                    string returnUrl = HttpContext.Request.Query["returnUrl"];
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "UserProfile", new { Area = "Member" });
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifreniz yanlış!");
                    return View(p);
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    ImageUrl = "default.png",
                    PhoneNumber = p.PhoneNumber,
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.Username,
                    Email = p.Mail
                };
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            
            return View(p);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> ForgotPassword(ForgotPasswordViewModel fpvm)
        {
            var user = await _userManager.FindByEmailAsync(fpvm.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ChangePassword", "Login", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage message = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("ISM Traversal", "ismtraversalresmi@gmail.com");

            message.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("Kullanıcı", fpvm.Mail);
            message.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Aşağıdaki bağlantıya tıklayarak şifrenizi sıfırlayabilirsiniz:\n" + passwordResetTokenLink;
            message.Body = bodyBuilder.ToMessageBody();

            message.Subject = "ISM Traversal - Şifre Sıfırlama Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mail", "password");
            client.Send(message);
            client.Disconnect(true);

            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //error
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), cpvm.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
