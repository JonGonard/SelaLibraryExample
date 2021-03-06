﻿using System.ComponentModel;
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

    public MainWindow()
    {
      _viewFactory = new LibraryViewFactory();

      CatalogViewModel = new CatalogViewModel(_viewFactory);

      CreateSampleInfo();

      InitializeComponent();

      DataContext = CatalogViewModel;

      CatalogCollectionView = CollectionViewSource.GetDefaultView(CatalogViewModel.Library);
    }

    public CatalogViewModel CatalogViewModel { get; set; }

    public ICollectionView CatalogCollectionView { get; set; }

    private void CreateSampleInfo()
    {
      var book2 = new Book(2, "The Catcher in the Rye") { Genre = Genre.Thriller, Author = "J.D. Salinger" };
      var book1 = new Book(1, "Ender's Game") { Genre = Genre.Thriller, Author = "Orson Scott Card"};
      var book3 = new Book(3, "WPF Unleashed") { Genre = Genre.Professional, Author = "Adam Nathan" };
      var book4 = new Jurnal(4, "Popular Mechanics") { Genre = Genre.Professional };

      CatalogViewModel.Library.AddItem(book1);
      CatalogViewModel.Library.AddItem(book2);
      CatalogViewModel.Library.AddItem(book3);
      CatalogViewModel.Library.AddItem(book4);
    }

    private void CatalogList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      CatalogViewModel.ShowItem(CatalogCollectionView.CurrentItem as CatalogItem);
    }
  }
}
