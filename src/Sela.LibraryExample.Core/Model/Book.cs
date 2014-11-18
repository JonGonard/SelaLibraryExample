using System;
using System.Collections.ObjectModel;

namespace Sela.LibraryExample.Core.Model
{
  public class Book : CatalogItem
  {
    private string _author;
    private string _publisher;

    public Book(int isbn, string title) : base(isbn, title)
    {
    }

    public Book(string title, int isbn, Genre genre, int issue, DateTime releaseDate,
      ObservableCollection<string> topics, string author, string publisher)
      : base(title, isbn, genre, issue, releaseDate, topics)
    {
      Author = author;
      Publisher = publisher;
    }

    public string Author
    {
      get { return _author; }
      set
      {
        if (value == _author)
          return;
        _author = value;
        OnPropertyChanged();
      }
    }

    public string Publisher
    {
      get { return _publisher; }
      set
      {
        if (value == _publisher)
          return;
        _publisher = value;
        OnPropertyChanged();
      }
    }
  }
}