using Sela.LibraryExample.Core.Infrastructure;

namespace Sela.LibraryExample.Core.Model
{
    public class Copy : NotifyObject
    {
        private int _isbn;
        private int _copyNumber;
        private string _lentTo;

        public Copy(int isbn, int copyNumber)
        {
            ISBN = isbn;
            CopyNumber = copyNumber;
        }

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

        public int CopyNumber
        {
            get { return _copyNumber; }
            private set
            {
                if (value == _copyNumber)
                    return;
                _copyNumber = value;
                OnPropertyChanged();
            }
        }

        public string LentTo
        {
            get { return _lentTo; }
            private set
            {
                if (value == _lentTo)
                    return;
                _lentTo = value;
                OnPropertyChanged();
                OnPropertyChanged("IsLent");
            }
        }

        public bool IsLent
        {
            get { return !string.IsNullOrEmpty(LentTo); }
        }

        public string Remarks { get; set; }

        public Result LendTo(string lender)
        {
            if (!IsLent)
            {
                LentTo = lender;

                return Result.Success();
            }

            return Result.Fail(Consts.COPY_LENT);
        }

        public Result Return()
        {
            LentTo = string.Empty;

            return Result.Success();
        }
    }
}