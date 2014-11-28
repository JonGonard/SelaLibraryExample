using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Sela.LibraryExample.UI.Helpers
{
  public class ListEnumExtension : MarkupExtension
  {
    public ListEnumExtension()
    {
      DisplayEmptyValue = false;
    }

    public ListEnumExtension(Type enumType): this()
    {
      EnumType = enumType;
    }

    public Type EnumType { get; set; }

    public object EmptyValue { get; set; }

    public bool DisplayEmptyValue { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      var array = Enum.GetValues(EnumType);

      if (DisplayEmptyValue)
        return array.Cast<object>().Where(x => x != EmptyValue);
      else
        return array;
    }
  }
}
