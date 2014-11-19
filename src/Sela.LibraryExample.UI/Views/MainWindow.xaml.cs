using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;
using Sela.LibraryExample.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sela.LibraryExample.UI.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private IViewFactory _viewFactory;

    public CatalogViewModel CatalogViewModel { get; set; }

    public MainWindow()
    {
      _viewFactory = new LibraryViewFactory();

      CatalogViewModel = new CatalogViewModel(_viewFactory);

      CreateSampleInfo();

      InitializeComponent();

      DataContext = CatalogViewModel;
    }

    private void CreateSampleInfo()
    {
      var book1 = new Book(1, "Ender's Game") { Genre = Genre.Thriller };
      var book2 = new Book(2, "Speaker for the dead") { Genre = Genre.Thriller };
      var book3 = new Book(3, "Xenocide") { Genre = Genre.Thriller };
      var book4 = new Book(4, "Children of the mind") { Genre = Genre.Thriller };

      CatalogViewModel.Library.AddItem(book1);
      CatalogViewModel.Library.AddItem(book2);
      CatalogViewModel.Library.AddItem(book3);
      CatalogViewModel.Library.AddItem(book4);
    }
  }
}
