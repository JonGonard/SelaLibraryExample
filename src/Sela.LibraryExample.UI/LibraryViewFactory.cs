using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.ViewModel;
using Sela.LibraryExample.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sela.LibraryExample.UI
{
  public class LibraryViewFactory : IViewFactory
  {
    public Window CreateNewItemView(AddNewItemViewModel addNewItemViewModel)
    {
      var newItemView = new NewItemView() { DataContext = addNewItemViewModel };

      return newItemView;
    }
  }
}
