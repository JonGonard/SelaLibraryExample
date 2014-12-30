using Sela.LibraryExample.Core.Infrastructure;
using Sela.LibraryExample.Core.Model;

namespace Sela.LibraryExample.Core.ViewModel
{
  public class CopyViewModel : NotifyObject
  {
    private readonly IViewFactory _viewFactory;
    private Copy _copy;

    public CopyViewModel(IViewFactory viewFactory, Copy copy)
    {
      _viewFactory = viewFactory;
      _copy = copy;

      LendCopyCommand = new RelayCommand(x => LendCopy(), x => !_copy.IsLent);
      ReturnCopyCommand = new RelayCommand(x => ReturnCopy(), x => _copy.IsLent);
    }

    public RelayCommand LendCopyCommand { get; set; }
    public RelayCommand ReturnCopyCommand { get; set; }

    public Copy Copy
    {
      get { return _copy; }
      private set
      {
        if (Equals(value, _copy))
          return;

        _copy = value;
        OnPropertyChanged();
      }
    }

    public void LendCopy()
    {
      var lendCopyViewModel = new LendCopyViewModel(Copy);

      var lendCopyView = _viewFactory.CreateLendCopyView(lendCopyViewModel);

      var windowResult = lendCopyView.ShowDialog();

      if (windowResult.HasValue && windowResult.Value)
      {
        var lendResult = Copy.LendTo(lendCopyViewModel.LendTo);

        if (!lendResult)
          MessageBox.ShowError(lendResult.Error);
      }
    }

    public void ReturnCopy()
    {
      var result = Copy.Return();

      if (!result)
        MessageBox.ShowError(result.Error);
    }
  }
}