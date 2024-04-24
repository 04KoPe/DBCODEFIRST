using System;
using System.Collections.Generic;

namespace DBFIRST.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderQuantity { get; set; }

    public int? ProductId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
