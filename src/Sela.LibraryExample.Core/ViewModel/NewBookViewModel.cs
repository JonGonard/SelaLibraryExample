using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class NewBookViewModel : NewItemSpecificViewModel
  {
    private string _author;
    private string _publisher;

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

    protected override CatalogItem CreateSpecificType()
    {
      return new Book(ISBN, Title);
    }

    protected override void AssignSpecificProperties(CatalogItem newItem)
    {
      var newBook = newItem as Book;

      newBook.Author = Author;
      newBook.Publisher = Publisher;
    }
  }
}