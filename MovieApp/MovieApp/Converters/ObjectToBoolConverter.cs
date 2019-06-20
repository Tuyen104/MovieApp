using System;
using System.Collections;
using Xamarin.Forms;

namespace MovieApp.Converters
{
    public class ObjectToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case int intValue:
                case decimal decimalValue:
                case double doubleValue:
                    return System.Convert.ToDouble(value) != 0;
                case string stringValue:
                    return !string.IsNullOrEmpty(stringValue);
                case IEnumerable enumerableValue:
                    return enumerableValue.GetEnumerator().MoveNext();
            }

            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
