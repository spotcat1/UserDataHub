

using Application.Dto_s.CarDto;
using FluentValidation;
using System.Globalization;

namespace Infrastructure.CrossCutting.Validations.CarVaidation
{
    public class CarValidator : AbstractValidator<AddUpdateCarDto>
    {
        public CarValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .Matches("^[آ-یa-zA-Z]+$")
                .NotEmpty()
                .WithName("نام");

            RuleFor(x => x.CreatedDate)
                .Must(BeValidShamsiDate)
                .NotEmpty()
                .WithName("تاریخ تولید");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithName("مدل خودرو");

            RuleFor(x => x.Price)
                .NotEmpty()
                .Must(ValidPrice)
                .WithName("قیمت");

        }



        private bool BeValidShamsiDate(string date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            return DateTime.TryParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate)
                && parsedDate.Year >= persianCalendar.MinSupportedDateTime.Year
                && parsedDate.Year <= persianCalendar.MaxSupportedDateTime.Year
                && parsedDate.Month >= 1
                && parsedDate.Month <= 12
                && parsedDate.Day >= 1
                && parsedDate.Day <= persianCalendar.GetDaysInMonth(parsedDate.Year, parsedDate.Month);
        }


        private bool ValidPrice(double price)
        {
            return price >= 0;
        }
    }
}
