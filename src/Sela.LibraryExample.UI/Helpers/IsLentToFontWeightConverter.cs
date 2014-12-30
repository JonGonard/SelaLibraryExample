using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sela.LibraryExample.UI.Helpers
{
  public class IsLentToFontWeightConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var isLent = (bool) value;

      return isLent ? FontWeights.Bold : FontWeights.Normal;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}