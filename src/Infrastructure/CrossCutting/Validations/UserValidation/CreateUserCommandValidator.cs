

using Application.Commands;
using FluentValidation;

namespace Infrastructure.CrossCutting.Validations.UserValidation
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;


            RuleFor(x => x.dto)
                .NotEmpty()
                .SetValidator(new UserValidator())
                .WithName("مدل")
                .WithMessage("خطا در مدل فرستاده شدخ");


        }




       




    }
}
