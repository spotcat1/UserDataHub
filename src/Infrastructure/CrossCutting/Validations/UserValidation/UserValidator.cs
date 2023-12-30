

using Application.Dto_s.UserDto;
using Application.Exceptions;
using FluentValidation;

namespace Infrastructure.CrossCutting.Validations.UserValidation
{
    public class UserValidator:AbstractValidator<AddUpdateUserDto>
    {
        public UserValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.GenderId)
                .NotEmpty()
                .WithName("شناسه جنسیت");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[آ-یa-zA-Z]+( [آ-یa-zA-Z]+)?$")
                .WithName("نام");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[آ-یa-zA-Z]+( [آ-یa-zA-Z]+)?$")
                .WithName("نام خانوادگی");

            RuleFor(x => x.IdentityCode)
                .NotEmpty()
                .Length(11)
                .Matches("^[0-9]*$")
                .WithName("کد ملی");


            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(ValidateBirthDate)
                .WithName("تاریخ تولد");

            RuleFor(x => x.Nationality)
                .Matches("^[آ-یa-zA-Z]+( [آ-یa-zA-Z]+)?$")
                .MaximumLength(50)
                .WithName("ملیت");


        }


        private bool ValidateBirthDate(DateTime birthDate)
        {
            
            bool IsValid = birthDate.Year >= 1800 && birthDate.Year <= DateTime.Now.Year && // Ensure the year is after 1800 and not in the future
                   birthDate.Month >= 1 && birthDate.Month <= 12 && // Ensure the month is between 1 and 12
                   birthDate.Day >= 1 && birthDate.Day <= 30; // Ensure the day is between 1 and 30


            

            return IsValid;
        }


    }
}
