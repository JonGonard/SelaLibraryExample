using System;
using System.Collections.ObjectModel;

namespace Sela.LibraryExample.Core.Model
{
  public class Book : CatalogItem
  {
    public Book(string title, int isbn, Genre genre, int issue, DateTime releaseDate,
      ObservableCollection<string> topics, string author, string publisher)
      : base(title, isbn, genre, issue, releaseDate, topics)
    {
      Author = author;
      Publisher = publisher;
    }

    public string Author { get; private set; }

    public string Publisher { get; private set; }
  }
}