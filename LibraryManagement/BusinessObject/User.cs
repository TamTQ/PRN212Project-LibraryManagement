﻿using System;
using System.Collections.Generic;

namespace LibraryManagement.BusinessObject;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Lend> Lends { get; set; } = new List<Lend>();
}
