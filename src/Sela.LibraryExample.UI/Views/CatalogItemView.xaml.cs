using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Sela.LibraryExample.Core.Model;
using Sela.LibraryExample.Core.ViewModel;

namespace Sela.LibraryExample.UI.Views
{
  /// <summary>
  /// Interaction logic for CatalogItemView.xaml
  /// </summary>
  public partial class CatalogItemView : Window
  {
    public CatalogItemView()
    {
      InitializeComponent();
    }

    public CatalogItemViewModel CatalogItemViewModel { get; private set; }

    private void CatalogItemView_OnLoaded(object sender, RoutedEventArgs e)
    {
      CatalogItemViewModel = DataContext as CatalogItemViewModel;
    }

    private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      CatalogItemViewModel.ShowCopy(CopiesList.SelectedItem as Copy);
    }
  }
}
