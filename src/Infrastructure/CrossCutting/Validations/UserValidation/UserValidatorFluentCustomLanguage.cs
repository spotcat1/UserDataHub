

namespace Infrastructure.CrossCutting.Validations.UserValidation
{
    public class UserValidatorFluentCustomLanguage : FluentValidation.Resources.LanguageManager
    {
        public UserValidatorFluentCustomLanguage()
        {
            Culture = new System.Globalization.CultureInfo("fa-IR");


            AddTranslation("fa", "NotEmptyValidator", "{PropertyName}   الزامی میباشد ");
            AddTranslation("fa", "MaximumLengthValidator", "{PropertyName} بیش از حد مشخص شده است  طول ");
            //AddTranslation("fa", "LengthValidator", "{PropertyName}   الزامی میباشد ");
            //AddTranslation("fa", "RegularExpressionValidator", "{PropertyName}  باید فقط حاوی حروف باشد ");
            //AddTranslation("fa", "RegularExpressionValidator", "{PropertyName}   باید فقط حاوی ارقام باشد ");

        }
    }
}
