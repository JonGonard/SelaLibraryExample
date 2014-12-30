using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class LendCopyViewModel : NotifyObject
  {
    private Copy _copy;
    private string _lendTo;

    public LendCopyViewModel(Copy copy)
    {
      _copy = copy;
    }

    public Copy Copy
    {
      get { return _copy; }
      set
      {
        if (Equals(value, _copy))
          return;
        _copy = value;
        OnPropertyChanged();
      }
    }

    public string LendTo
    {
      get { return _lendTo; }
      set
      {
        if (value == _lendTo)
          return;
        _lendTo = value;
        OnPropertyChanged();
      }
    }
  }
}