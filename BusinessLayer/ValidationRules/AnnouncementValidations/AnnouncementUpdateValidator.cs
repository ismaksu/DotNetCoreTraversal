using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidations
{
    public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlığı boş geçemezsiniz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru içeriğini boş geçemezsiniz.");

            RuleFor(x => x.Title).MinimumLength(4).WithMessage("Duyuru başlığı en az 4 karakter olmak zorundadır.");
            RuleFor(x => x.Content).MinimumLength(15).WithMessage("Duyuru içeriği en az 15 karakter olmak zorundadır.");

            RuleFor(x => x.Title).MaximumLength(65).WithMessage("Duyuru başlığı en fazla 65 karakter olmalıdır.");
            RuleFor(x => x.Title).MaximumLength(850).WithMessage("Duyuru içeriği en fazla 850 karakter olmalıdır.");
        }
    }
}
