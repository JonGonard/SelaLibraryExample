﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;
using MessageBox = Sela.LibraryExample.Core.Infrastructure.MessageBox;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class CatalogViewModel : NotifyObject
  {
    private IViewFactory _viewFactory;

    public CatalogViewModel(IViewFactory viewFactory)
    {
      _viewFactory = viewFactory;
      RemoveItemCommand = new RelayCommand(x => RemoveItem((CatalogItem)x));
      AddNewItemCommand = new RelayCommand(x => AddNewItem());
    }

    public Library Library
    {
      get { return Library.Instance; }
    }

    public RelayCommand RemoveItemCommand { get; private set; }

    public RelayCommand AddNewItemCommand { get; private set; }

    private void RemoveItem(CatalogItem item)
    {
      if (MessageBox.ShowQuestion("Are you sure you want to delete " + item.Title) == MessageBoxResult.Yes)
      {
        var result = Library.RemoveItem(item);

        if (!result)
        {
          MessageBox.ShowError(result.Error);
        }
      }
    }

    private void AddNewItem()
    {
      var newItemViewModel = new AddNewItemViewModel();

      Window newItemView = _viewFactory.CreateNewItemView(newItemViewModel);

      var result = newItemView.ShowDialog();

      if (result.HasValue && result.Value)
      {
        var addResult = Library.AddItem(newItemViewModel.ItemSpecificViewModel.CreateNewItem());

        if (!addResult)
        {
          MessageBox.ShowError(addResult.Error);
        }
      }
    }
  }
}