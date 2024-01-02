using Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCutting.Validations.CarVaidation
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.dto)
                .NotEmpty()
                .SetValidator(new CarValidator())
                .WithName("مدل")
                .WithMessage("خطا در مدل فرستاده شدخ");
        }
    }
}
