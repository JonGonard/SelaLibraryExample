using System;
using Sela.LibraryExample.Core.Infrastructure;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class AddNewItemViewModel : NotifyObject
  {
    private ItemType _newItemType;
    private NewItemSpecificViewModel _newItemSpecificViewModel;

    public AddNewItemViewModel()
    {
      _newItemSpecificViewModel = new NewBookViewModel();
    }

    public ItemType NewItemType
    {
      get { return _newItemType; }
      set
      {
        if (value == _newItemType)
          return;
        _newItemType = value;
        OnPropertyChanged();

        switch (value)
        {
          case ItemType.Book:
            NewItemSpecificViewModel = new NewBookViewModel();
            break;
          case ItemType.Jurnal:
            NewItemSpecificViewModel = new NewJurnalViewModel();
            break;
          default:
            throw new ArgumentOutOfRangeException("value");
        }
      }
    }

    public NewItemSpecificViewModel NewItemSpecificViewModel
    {
      get { return _newItemSpecificViewModel; }
      private set
      {
        if (Equals(value, _newItemSpecificViewModel))
          return;
        _newItemSpecificViewModel = value;
        OnPropertyChanged();
      }
    }
  }
}
