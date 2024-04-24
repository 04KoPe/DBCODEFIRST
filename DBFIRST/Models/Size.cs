using System;
using System.Collections.Generic;

namespace DBFIRST.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public double? ShoeSize { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
