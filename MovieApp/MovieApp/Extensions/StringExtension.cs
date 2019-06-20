using System;
namespace MovieApp.Extensions
{
    public static class StringExtension
    {
        public static bool EqualsIgnoreCase(this string value, string compareString)
        {
            return string.Equals(value, compareString, StringComparison.OrdinalIgnoreCase);
        }
    }
}
