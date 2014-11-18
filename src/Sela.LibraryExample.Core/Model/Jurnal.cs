using System;
using System.Collections.ObjectModel;

namespace Sela.LibraryExample.Core.Model
{
  public class Jurnal : CatalogItem
  {
    private string _editor;

    public Jurnal(int isbn, string title) : base(isbn, title)
    {
    }

    public Jurnal(string title, int isbn, Genre genre, int issue, DateTime releaseDate,
      ObservableCollection<string> topics, string editor)
      : base(title, isbn, genre, issue, releaseDate, topics)
    {
      Editor = editor;
    }

    public string Editor
    {
      get { return _editor; }
      set
      {
        if (value == _editor)
          return;
        _editor = value;
        OnPropertyChanged();
      }
    }
  }
}