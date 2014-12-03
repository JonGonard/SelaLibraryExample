using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sela.LibraryExample.Core.Infrastructure;
using System.Collections.Specialized;

namespace Sela.LibraryExample.Core.Model
{
  public abstract class CatalogItem : NotifyObject, IEnumerable<Copy>, INotifyCollectionChanged
  {
    private readonly Dictionary<int, Copy> _copies;
    private int _isbn;
    private string _title;
    private Genre _genre;
    private ObservableCollection<string> _topics;
    private DateTime _releaseDate;
    private int _issue;

    private CatalogItem()
    {
      _copies = new Dictionary<int, Copy>();
      Topics = new ObservableCollection<string>();
    }

    protected CatalogItem(int isbn, string title)
      : this()
    {
      _isbn = isbn;
      _title = title;

    }

    protected CatalogItem(string title, int isbn, Genre genre, int issue, DateTime releaseDate,
      ObservableCollection<string> topics)
      : this()
    {
      Title = title;
      ISBN = isbn;
      Genre = genre;
      Issue = issue;
      ReleaseDate = releaseDate;
      Topics = topics;
    }

    #region Properties

    public int ISBN
    {
      get { return _isbn; }
      private set
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
      private set
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
      private set
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

    #endregion

    public Result<Copy> AddCopy(int copyNumber)
    {
      if (!_copies.ContainsKey(copyNumber))
      {
        var copy = new Copy(ISBN, copyNumber);

        _copies.Add(copyNumber, copy);

        var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, copy);

        OnCollectionChanged(args);

        return Result<Copy>.Success(copy);
      }

      return Result<Copy>.Fail(Consts.COPY_EXISTS);
    }

    public Result<Copy> AddCopy()
    {
      return AddCopy(_copies.Count > 0 ? _copies.Keys.Max() + 1 : 1);
    }

    public Result RemoveCopy(int copyNumber)
    {
      Result result = IsCopyAvailable(copyNumber);

      if (result.DidSucceed)
      {
        _copies.Remove(copyNumber);

        var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

        OnCollectionChanged(args);
      }

      return result;
    }

    public Result RemoveCopy(Copy copy)
    {
      return RemoveCopy(copy.CopyNumber);
    }

    public IEnumerator<Copy> GetEnumerator()
    {
      return _copies.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public Copy this[int copyNumber]
    {
      get { return _copies[copyNumber]; }
      set
      {
        var oldCopy = _copies[copyNumber];

        _copies[copyNumber] = value;

        var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

        OnCollectionChanged(args);
      }
    }

    private Result IsCopyAvailable(int copyNumber)
    {
      if (_copies.ContainsKey(copyNumber))
        return _copies[copyNumber].IsLent ? Result.Fail(Consts.COPY_LENT) : Result.Success();

      return Result.Fail(Consts.COPY_DOESNT_EXIST);
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
    {
      var temp = CollectionChanged;

      if (temp != null)
        temp(this, args);
    }
  }
}