using System;
using System.Globalization;
using System.Windows.Data;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.UI.Helpers
{
  public class IsbnToTitleConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      int isbn = System.Convert.ToInt32(value);

      return Library.Instance[isbn].Title;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}