

using Application.Commands;
using FluentValidation;

namespace Infrastructure.CrossCutting.Validations.CarVaidation
{
    public class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
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
