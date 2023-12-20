

namespace Infrastructure.CrossCutting.Validations.UserValidation
{
    public class UserValidatorFluentCustomLanguage : FluentValidation.Resources.LanguageManager
    {
        public UserValidatorFluentCustomLanguage()
        {
            Culture = new System.Globalization.CultureInfo("fa-IR");


            AddTranslation("fa", "NotEmptyValidator", "{PropertyName}   الزامی میباشد ");
            AddTranslation("fa", "MaximumLengthValidator", "بیش از حد مشخص شده است{PropertyName}   طول ");
            AddTranslation("fa", "LengthValidator", "{PropertyName}   الزامی میباشد ");
            AddTranslation("fa", "MatchesLettersValidator", "{PropertyName}  باید فقط حاوی حروف باشد ");
            AddTranslation("fa", "MatchesNumbersValidator", "{PropertyName}   باید فقط حاوی ارقام باشد ");

        }
    }
}
