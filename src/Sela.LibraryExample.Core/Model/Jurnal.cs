using System;
using System.Collections.ObjectModel;

namespace Sela.LibraryExample.Core.Model
{
    public class Jurnal : CatalogItem
    {
        public Jurnal(string title, int isbn, Genre genre, int issue, DateTime releaseDate,
            ObservableCollection<string> topics, string editor)
            : base(title, isbn, genre, issue, releaseDate, topics)
        {
            Editor = editor;
        }

        public string Editor { get; private set; }
    }
}