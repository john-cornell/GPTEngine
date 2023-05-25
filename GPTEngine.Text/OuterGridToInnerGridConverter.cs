using System.Globalization;
using System.Windows.Data;
using System;

namespace GPTEngine.Text;

public class OuterGridToInnerGridWidthConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((double)value) - 50;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
