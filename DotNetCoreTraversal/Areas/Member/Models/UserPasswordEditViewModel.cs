using System.ComponentModel.DataAnnotations;

namespace DotNetCoreTraversal.Areas.Member.Models
{
    public class UserPasswordEditViewModel
    {
        [Required(ErrorMessage = "Lütfen mevcut şifrenizi giriniz.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Lütfen yeni bir şifre belirleyiniz.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Lütfen yeni şifrenizi doğrulayınız.")]
        public string ConfirmPassword { get; set; }
    }
}
