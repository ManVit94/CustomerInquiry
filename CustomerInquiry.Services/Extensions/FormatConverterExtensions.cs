using System;
using System.Globalization;

namespace CustomerInquiry.Services.Extensions
{
    internal static class FormatConverterExtensions
    {
        public static string ToFormattedString(this DateTime dateTime)
        {
            return dateTime.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"));
        }

        public static string ToFormattedString(this decimal number)
        {
            return number.ToString(CultureInfo.InvariantCulture);
        }
    }
}
