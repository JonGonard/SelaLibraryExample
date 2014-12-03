using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Sela.LibraryExample.UI.Helpers
{
  public class IsLentToForegroundConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var isLent = (bool) value;

      return new SolidColorBrush(isLent ? Colors.Navy : Colors.Black);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}