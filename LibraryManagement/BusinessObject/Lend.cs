using System;
using System.Collections.Generic;

namespace LibraryManagement.BusinessObject;

public partial class Lend
{
    public int LendId { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public DateOnly LendDate { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
