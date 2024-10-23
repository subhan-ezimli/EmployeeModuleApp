using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Common.Core.Validations
{
    public static class ValidationExtensions
    {
        private static ValidationException ValidExp(string message)
        {
            return new ValidationException(message);
        }
        public static T IsNotNull<T>(this T model, [CallerArgumentExpression("model")] string item = "")
        {
            if (model is not null)
                return model;
            else throw ValidExp($"{item} is null!");
        }

        public static string IsNotBlank(this string model, [CallerArgumentExpression("model")] string item = "")
        {
            if (String.IsNullOrEmpty(model))
                throw ValidExp($"{item} is null or blank!");
            return model;
        }

        public static string HasMinLength(this string model
            , int min, [CallerArgumentExpression("model")] string item = "",
            [CallerArgumentExpression("min")] string minItem = ""
            )
        {
            model.IsNotBlank();
            if (model.Length >= min)
                return model;
            else throw ValidExp($"{item} with {model} should be at least {min} length");
        }

        public static string IsAlphabetical(this string model,
            [CallerArgumentExpression("model")] string item = "")
        {
            if (model.All(char.IsLetter))
                return model;
            else throw ValidExp($"{model} should have only alphabetical characters");
        }

        public static string IsValidRegExp(this string model, string pattern, [CallerArgumentExpression("model")] string item = "")
        {
            model.IsNotBlank();
            if (Regex.IsMatch(model, pattern))
                return model;
            else throw ValidExp($"{item} is not a valid data within {pattern}");
        }

        public static T IsGreaterThan<T>(this T model, T otherModel, [CallerArgumentExpression("model")] string item = "",
            [CallerArgumentExpression("otherModel")] string otherItem = "")
            where T : IComparable<T>
        {
            if (model.CompareTo(otherModel) > 0)
                return model;
            else throw ValidExp($"{item} is not greater than {otherItem}");
        }
        public static string IsValidEmail(this string email, [CallerArgumentExpression("email")] string item="")
        {
            if (new EmailAddressAttribute().IsValid(email))
            {
                return email;
            }
            else throw ValidExp($"{item} is not a valid email address");
        }
    }
}
