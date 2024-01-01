

using Application.Dto_s.UserDto;
using Application.Exceptions;
using FluentValidation;
using System.Globalization;

namespace Infrastructure.CrossCutting.Validations.UserValidation
{
    public class UserValidator : AbstractValidator<AddUpdateUserDto>
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
                .Matches("^[آ-یa-zA-Z ]+$")
                .WithName("نام");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[آ-یa-zA-Z ]+$")
                .WithName("نام خانوادگی");

            RuleFor(x => x.IdentityCode)
                .NotEmpty()
                .Length(11)
                .Matches("^[0-9]+$")
                .WithName("کد ملی");


            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(BeValidShamsiDate)
                .WithName("تاریخ تولد");

            RuleFor(x => x.Nationality)
                .Matches("^[آ-یa-zA-Z ]+$")
                .MaximumLength(50)
                .WithName("ملیت");


        }


        private bool BeValidShamsiDate(string date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            // Check if the string can be parsed as a valid Shamsi (Persian) date
            return DateTime.TryParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate)
                && parsedDate.Year >= persianCalendar.MinSupportedDateTime.Year
                && parsedDate.Year <= persianCalendar.MaxSupportedDateTime.Year
                && parsedDate.Month >= 1
                && parsedDate.Month <= 12
                && parsedDate.Day >= 1
                && parsedDate.Day <= persianCalendar.GetDaysInMonth(parsedDate.Year, parsedDate.Month);
        }


    }
}
