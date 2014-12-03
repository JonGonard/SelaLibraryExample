using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class CopyViewModel : NotifyObject
  {
    private Copy _copy;

    public CopyViewModel(Copy copy)
    {
      _copy = copy;
    }

    public Copy Copy
    {
      get { return _copy; }
      private set
      {
        if (Equals(value, _copy))
          return;

        _copy = value;
        OnPropertyChanged();
      }
    }

    public void LendCopy()
    {
      
    }

    public void ReturnCopy()
    {
      var result = Copy.Return();

      if (!result)
        MessageBox.ShowError(result.Error);
    }
  }
}
