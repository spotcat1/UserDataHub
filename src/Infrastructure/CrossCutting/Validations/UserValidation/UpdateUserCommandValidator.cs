

using Application.Commands;
using FluentValidation;

namespace Infrastructure.CrossCutting.Validations.UserValidation
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.dto)
                .NotEmpty()
                .SetValidator(new UserValidator())
                .WithName("مدل");
        }
    }
}
