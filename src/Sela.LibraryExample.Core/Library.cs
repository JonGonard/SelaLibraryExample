using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core
{
  public class Library : NotifyObject, IEnumerable<CatalogItem>
  {
    private static Library _instance = new Library();

    private Library()
    {
      Catalog = new ObservableDictionary<int, CatalogItem>();
    }

    private ObservableDictionary<int, CatalogItem> Catalog { get; set; }

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
  }
}