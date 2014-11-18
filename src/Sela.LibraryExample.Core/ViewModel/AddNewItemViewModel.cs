using System;
using Sela.LibraryExample.Core.Infrastructure;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class AddNewItemViewModel : NotifyObject
  {
    private ItemTypes _newItemType;
    private ItemSpecificViewModel _itemSpecificViewModel;

    public ItemTypes NewItemType
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
          case ItemTypes.Book:
            ItemSpecificViewModel = new BookViewModel();
            break;
          case ItemTypes.Jurnal:
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
