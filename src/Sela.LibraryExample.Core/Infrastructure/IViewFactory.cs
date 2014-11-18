using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sela.LibraryExample.Core.ViewModel;

namespace Sela.LibraryExample.Core.Infrastructure
{
  public interface IViewFactory
  {
    Window CreateNewItemView(AddNewItemViewModel addNewItemViewModel);
  }
}
