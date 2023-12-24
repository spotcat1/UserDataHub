﻿

using Application.Dto_s.UserDto;
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
                .Matches("^[آ-یa-zA-Z]*$")
                .WithName("نام");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[آ-یa-zA-Z]*$")
                .WithName("نام خانوادگی");

            RuleFor(x => x.IdentityCode)
                .NotEmpty()
                .Length(11)
                .Matches("^[0-9]*$")
                .WithName("کد ملی");


            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithName("تاریخ تولد");

            RuleFor(x => x.Nationality)
                .MaximumLength(50)
                .WithName("ملیت");
        }
    }
}
