using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.MessageBody).MinimumLength(30).WithMessage("Mesajınız en az 30 karakter olmalıdır.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim kısmı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Subject).MaximumLength(60).WithMessage("Konu başlığı en fazla 60 karakter olmalıdır.");
            RuleFor(x => x.MessageBody).MaximumLength(700).WithMessage("Mesajınız en fazla 700 karakter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim kısmı en fazla 50 karakter olmalıdır.");

        }
    }
}
