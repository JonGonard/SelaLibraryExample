using System.Windows;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.ViewModel;
using Sela.LibraryExample.UI.Views;

namespace Sela.LibraryExample.UI
{
  public class LibraryViewFactory : IViewFactory
  {
    public Window CreateNewItemView(AddNewItemViewModel addNewItemViewModel)
    {
      var newItemView = new NewItemView {DataContext = addNewItemViewModel};

      return newItemView;
    }

    public Window CreateItemView(CatalogItemViewModel viewModel)
    {
      var itemView = new CatalogItemView {DataContext = viewModel};

      return itemView;
    }
  }
}