using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace UI.Extras
{
    public class AgeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int age)
            {
                if (age < 20) return Brushes.LightGreen;
                if (age < 40) return Brushes.Khaki;
                return Brushes.IndianRed;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}