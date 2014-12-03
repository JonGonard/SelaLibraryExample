using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sela.LibraryExample.Core.Infrastructure;
using System.Collections.Specialized;

namespace Sela.LibraryExample.Core.Model
{
  public class Library : NotifyObject, IEnumerable<CatalogItem>, INotifyCollectionChanged
  {
    private static Library _instance = new Library();

    private Library()
    {
      Catalog = new Dictionary<int, CatalogItem>();
    }

    private Dictionary<int, CatalogItem> Catalog { get; set; }

    public static Library Instance
    {
      get { return _instance; }
    }

    public CatalogItem this[int isbn]
    {
      get { return Catalog[isbn]; }
    }

    public IEnumerator<CatalogItem> GetEnumerator()
    {
      return Catalog.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public Result AddItem(CatalogItem item)
    {
      if (!Catalog.ContainsKey(item.ISBN))
      {
        Catalog.Add(item.ISBN, item);

        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item);

        OnCollectionChanged(e);

        return Result.Success();
      }

      return Result.Fail(Consts.ITEM_IN_CATALOG);
    }

    public Result RemoveItem(int isbn)
    {
      if (Catalog.ContainsKey(isbn))
      {
        if (!Catalog[isbn].Any())
        {
          Catalog.Remove(isbn);

          var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

          OnCollectionChanged(e);

          return Result.Success();
        }

        return Result.Fail(Consts.ITEM_CONTAINS_COPIES);
      }

      return Result.Fail(Consts.ITEM_NOT_IN_CATALOG);
    }

    public Result RemoveItem(CatalogItem item)
    {
      return RemoveItem(item.ISBN);
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      var temp = CollectionChanged;

      if (temp != null)
        temp(this, e);
    }
  }
}