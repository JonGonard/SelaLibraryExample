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
    public ListEnumExtension(Type enumType)
    {
      EnumType = enumType;
      DisplayNullValue = false;
    }

    public Type EnumType { get; set; }

    public object NullValue { get; set; }

    public bool DisplayNullValue { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return DisplayNullValue 
        ? Enum.GetValues(EnumType)).Where(x => x != NullValue)
        : Enum.GetValues(EnumType);
    }
  }
}
