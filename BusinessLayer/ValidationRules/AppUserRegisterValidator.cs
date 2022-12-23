using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsminizi boş geçemezsiniz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadınızı boş geçemezsiniz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adınızı boş geçemezsiniz.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresinizi boş geçemezsiniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre kısmını boş geçemezsiniz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar kısmını boş geçemezsiniz.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakterden oluşan bir isim giriniz.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Lütfen en az 3 karakterden oluşan bir soyisim giriniz.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Lütfen en az 3 karakterden oluşan bir kullanıcı ismi giriniz.");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifreniz en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.ConfirmPassword).MinimumLength(5).WithMessage("Şifreniz en az 5 karakterden oluşmalıdır.");

            RuleFor(x => x.Name).MaximumLength(35).WithMessage("Adınız 35 karakterden fazla olamaz.");
            RuleFor(x => x.Surname).MaximumLength(40).WithMessage("Soyadınız 40 karakterden fazla olamaz.");
            RuleFor(x => x.Username).MaximumLength(17).WithMessage("Kullanıcı adınız çok uzun.");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Lütfen daha kısa bir mail adresi girmeyi deneyiniz.");
            RuleFor(x => x.Password).MaximumLength(40).WithMessage("Şifreniz en fazla 40 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.ConfirmPassword).MaximumLength(40).WithMessage("Şifreniz en fazla 40 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler birbiri ile uyuşmuyor, lütfen kontrol ediniz.");

        }
    }
}
