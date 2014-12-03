using System;

namespace Sela.LibraryExample.Core.Model
{
  [Flags]
  public enum Genre
  {
    Professional = 1,
    Comedy = 2,
    Thriller = 4,
    Romance = 8,
  }
}