using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator:AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bir rehber ismi giriniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber hakkında bir açıklama giriniz.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen 3 karakterden daha kısa bir isim girmeyiniz.");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Lütfen 10 karakterden daha kısa bir açıklama girmeyiniz.");

            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Lütfen rehber ismi olarak maksimum 40 karakter giriniz.");
            RuleFor(x => x.Description).MaximumLength(2500).WithMessage("Lütfen rehber açıklamasını kısaltınız. (Max: 2500 karakter)");
        }
    }
}
