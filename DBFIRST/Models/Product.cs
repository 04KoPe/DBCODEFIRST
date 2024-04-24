using System;
using System.Collections.Generic;

namespace DBFIRST.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? ProductPrice { get; set; }

    public string? ProductImage { get; set; }

    public string? ProductDescription { get; set; }

    public int? ProductQuantity { get; set; }

    public bool? IsExternal { get; set; }

    public string? ExternalUrl { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
