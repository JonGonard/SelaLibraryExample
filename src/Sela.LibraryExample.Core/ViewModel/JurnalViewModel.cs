using System.Windows.Input;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class JurnalViewModel : ItemSpecificViewModel
  {
    private string _editor;

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

    protected override CatalogItem CreateSpecificType()
    {
      return new Jurnal(ISBN, Title);
    }

    protected override void AssignSpecificProperties(CatalogItem newItem)
    {
      var newJurnal = newItem as Jurnal;

      newJurnal.Editor = Editor;
    }
  }
}