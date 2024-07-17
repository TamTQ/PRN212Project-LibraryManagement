using System;
using System.Collections.Generic;

namespace LibraryManagement.BusinessObject;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
