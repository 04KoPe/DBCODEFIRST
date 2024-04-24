using System;
using System.Collections.Generic;

namespace DBFIRST.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? AdminPassword { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
