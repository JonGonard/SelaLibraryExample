using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sela.LibraryExample.Core.Infrastructure;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class CatalogViewModel : NotifyObject
  {
    public CatalogViewModel()
    {
    }

    public Library Library
    {
      get { return Library.Instance; }
    }
  }
}