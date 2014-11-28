using System;
using Sela.LibraryExample.Core.Infrastructure;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class AddNewItemViewModel : NotifyObject
  {
    private ItemType _newItemType;
    private ItemSpecificViewModel _itemSpecificViewModel;

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
            ItemSpecificViewModel = new BookViewModel();
            break;
          case ItemType.Jurnal:
            ItemSpecificViewModel = new JurnalViewModel();
            break;
          default:
            throw new ArgumentOutOfRangeException("value");
        }
      }
    }

    public ItemSpecificViewModel ItemSpecificViewModel
    {
      get { return _itemSpecificViewModel; }
      private set
      {
        if (Equals(value, _itemSpecificViewModel))
          return;
        _itemSpecificViewModel = value;
        OnPropertyChanged();
      }
    }
  }
}
