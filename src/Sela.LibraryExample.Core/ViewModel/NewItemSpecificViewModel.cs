using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Navigation;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core.ViewModel
{
  public abstract class NewItemSpecificViewModel : NotifyObject
  {
    private int _isbn;
    private string _title;
    private Genre _genre;
    private ObservableCollection<string> _topics;
    private DateTime _releaseDate;
    private int _issue;
    public int ISBN
    {
      get { return _isbn; }
      set
      {
        if (value == _isbn)
          return;
        _isbn = value;
        OnPropertyChanged();
      }
    }

    public string Title
    {
      get { return _title; }
      set
      {
        if (value == _title)
          return;
        _title = value;
        OnPropertyChanged();
      }
    }

    public Genre Genre
    {
      get { return _genre; }
      set
      {
        if (value == _genre)
          return;
        _genre = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<string> Topics
    {
      get { return _topics; }
      set
      {
        if (Equals(value, _topics))
          return;
        _topics = value;
        OnPropertyChanged();
      }
    }

    public DateTime ReleaseDate
    {
      get { return _releaseDate; }
      set
      {
        if (value.Equals(_releaseDate))
          return;
        _releaseDate = value;
        OnPropertyChanged();
      }
    }

    public int Issue
    {
      get { return _issue; }
      set
      {
        if (value == _issue)
          return;
        _issue = value;
        OnPropertyChanged();
      }
    }

    public CatalogItem CreateNewItem()
    {
      var newItem = CreateSpecificType();

      newItem.Genre = Genre;
      newItem.Issue = Issue;
      newItem.ReleaseDate = ReleaseDate;
      //newItem.Topics = Topics;

      AssignSpecificProperties(newItem);

      return newItem;
    }

    protected abstract CatalogItem CreateSpecificType();

    protected abstract void AssignSpecificProperties(CatalogItem newItem);
  }
}