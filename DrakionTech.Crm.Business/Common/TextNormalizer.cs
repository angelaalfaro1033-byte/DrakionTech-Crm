using System.Globalization;
using System.Text.RegularExpressions;

namespace DrakionTech.Crm.Business.Common
{
    public static class TextNormalizer
    {
        public static string ToTitleCase(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            text = text.Trim().ToLower();

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static string ToUpper(string? text)
        {
            return string.IsNullOrWhiteSpace(text)
                ? string.Empty
                : text.Trim().ToUpper();
        }

        public static string ToLower(string? text)
        {
            return string.IsNullOrWhiteSpace(text)
                ? string.Empty
                : text.Trim().ToLower();
        }

        public static string NormalizeNit(string? nit)
        {
            if (string.IsNullOrWhiteSpace(nit))
                return string.Empty;

            nit = nit.Trim().ToUpper();

            return Regex.Replace(nit, @"\s+", "");
        }

        public static string? NormalizeEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return email.Trim().ToLower();
        }
    }
}