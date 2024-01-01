

using System.Globalization;

namespace Application.Helper
{
    public static class CommonHelpers
    {
        public static DateTime ConvertToMiladi(this string PersianDate)
        {
            return DateTime.Parse(PersianDate, new CultureInfo("fa-IR"));
        }

        public static string ConvertToPersianDate(this DateTime date)
        {
           
            return date.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
        }
    }
}
