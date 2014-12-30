using System.Windows;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.ViewModel;
using Sela.LibraryExample.UI.Views;

namespace Sela.LibraryExample.UI
{
  public class LibraryViewFactory : IViewFactory
  {
    public Window CreateNewItemView(AddNewItemViewModel viewModel)
    {
      var newItemView = new NewItemView {DataContext = viewModel};

      return newItemView;
    }

    public Window CreateItemView(CatalogItemViewModel viewModel)
    {
      var itemView = new CatalogItemView {DataContext = viewModel};

      return itemView;
    }

    public Window CreateCopyView(CopyViewModel viewModel)
    {
      var copyView = new CopyView {DataContext = viewModel};

      return copyView;
    }

    public Window CreateLendCopyView(LendCopyViewModel viewModel)
    {
      var lendCopyView = new LendCopyView {DataContext = viewModel};

      return lendCopyView;
    }
  }
}