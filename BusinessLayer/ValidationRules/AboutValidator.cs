using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.");
            RuleFor(x => x.Description).MinimumLength(60).WithMessage("Lütfen en az 60 karakterlik bir açıklama giriniz.");
            RuleFor(x => x.Description).MaximumLength(6000).WithMessage("Lütfen en fazla 6000 karakterlik bir açıklama giriniz.");
        }
    }
}
