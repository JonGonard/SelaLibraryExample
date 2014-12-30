using System.Windows;
using System.Windows.Input;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;
using MessageBox = Sela.LibraryExample.Core.Infrastructure.MessageBox;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class CatalogItemViewModel : NotifyObject
  {
    private readonly IViewFactory _viewFactory;
    private CatalogItem _catalogItem;
    private RelayCommand _addCopyCommand;
    private RelayCommand _removeCopyCommand;

    public CatalogItemViewModel(IViewFactory viewFactory, CatalogItem catalogItem)
    {
      _viewFactory = viewFactory;
      CatalogItem = catalogItem;

      AddCopyCommand = new RelayCommand(x => AddCopy());
      RemoveCopyCommand = new RelayCommand(x => RemoveCopy(x as Copy), x => CanRemoveCopy(x as Copy));
    }

    public RelayCommand AddCopyCommand
    {
      get { return _addCopyCommand; }
      private set
      {
        if (Equals(value, _addCopyCommand))
          return;
        _addCopyCommand = value;
        OnPropertyChanged();
      }
    }

    public RelayCommand RemoveCopyCommand
    {
      get { return _removeCopyCommand; }
      private set
      {
        if (Equals(value, _removeCopyCommand))
          return;
        _removeCopyCommand = value;
        OnPropertyChanged();
      }
    }

    public CatalogItem CatalogItem
    {
      get { return _catalogItem; }
      set
      {
        if (Equals(value, _catalogItem))
          return;

        _catalogItem = value;
        OnPropertyChanged();
      }
    }

    public void ShowCopy(Copy copy)
    {
      var viewModel = new CopyViewModel(_viewFactory, copy);

      Window itemView = _viewFactory.CreateCopyView(viewModel);

      itemView.Show();
    }

    public void AddCopy()
    {
      Result<Copy> result = CatalogItem.AddCopy();

      if (!result)
        MessageBox.ShowError(result.Error);
    }

    public bool CanRemoveCopy(Copy copy)
    {
      return copy != null && !copy.IsLent;
    }

    public void RemoveCopy(Copy copy)
    {
      Result result = CatalogItem.RemoveCopy(copy);

      if (!result)
        MessageBox.ShowError(result.Error);
    }
  }
}