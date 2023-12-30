

using Application.Commands;
using Application.Dto_s.UserDto;
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
                .WithName("مدل");


        }




       




    }
}
