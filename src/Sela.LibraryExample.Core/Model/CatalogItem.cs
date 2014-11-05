using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sela.LibraryExample.Core.Infrastructure;

namespace Sela.LibraryExample.Core.Model
{
    public abstract class CatalogItem : NotifyObject, IEnumerable<Copy>
    {
        private readonly ObservableDictionary<int, Copy> _copies;
        private int _isbn;
        private string _title;
        private Genre _genre;
        private ObservableCollection<string> _topics;
        private DateTime _releaseDate;
        private int _issue;

        protected CatalogItem(string title, int isbn, Genre genre, int issue, DateTime releaseDate,
            ObservableCollection<string> topics)
        {
            Title = title;
            ISBN = isbn;
            Genre = genre;
            Issue = issue;
            ReleaseDate = releaseDate;
            Topics = topics;

            _copies = new ObservableDictionary<int, Copy>();
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
            private set
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
            private set
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
            private set
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

                return Result<Copy>.Success(copy);
            }

            return Result<Copy>.Fail(Consts.COPY_EXISTS);
        }

        public Result<Copy> AddCopy()
        {
            return AddCopy(_copies.Keys.Max() + 1);
        }

        public Result RemoveCopy(int copyNumber)
        {
            Result result = IsCopyAvailable(copyNumber);

            if (result.DidSucceed)
                _copies.Remove(copyNumber);

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
            set { _copies[copyNumber] = value; }
        }

        private Result IsCopyAvailable(int copyNumber)
        {
            if (_copies.ContainsKey(copyNumber))
                return _copies[copyNumber].IsLent ? Result.Fail(Consts.COPY_LENT) : Result.Success();

            return Result.Fail(Consts.COPY_DOESNT_EXIST);
        }
    }
}