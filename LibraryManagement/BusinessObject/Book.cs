using System;
using System.Collections.Generic;

namespace LibraryManagement.BusinessObject;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<Lend> Lends { get; set; } = new List<Lend>();
}
