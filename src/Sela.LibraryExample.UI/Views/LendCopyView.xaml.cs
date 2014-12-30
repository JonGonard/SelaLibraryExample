using System.Windows;

namespace Sela.LibraryExample.UI.Views
{
  /// <summary>
  ///   Interaction logic for LendCopyView.xaml
  /// </summary>
  public partial class LendCopyView : Window
  {
    public LendCopyView()
    {
      InitializeComponent();
    }

    private void LendOnClick(object sender, RoutedEventArgs e)
    {
      DialogResult = true;

      Close();
    }

    private void CancelOnClick(object sender, RoutedEventArgs e)
    {
      DialogResult = false;

      Close();
    }
  }
}