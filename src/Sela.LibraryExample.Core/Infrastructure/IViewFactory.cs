using System.Windows;
using Sela.LibraryExample.Core.ViewModel;

namespace Sela.LibraryExample.Core.Infrastructure
{
  public interface IViewFactory
  {
    Window CreateNewItemView(AddNewItemViewModel viewModel);
    Window CreateItemView(CatalogItemViewModel viewModel);
    Window CreateCopyView(CopyViewModel viewModel);
    Window CreateLendCopyView(LendCopyViewModel viewModel);
  }
}