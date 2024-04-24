using System;
using System.Collections.Generic;

namespace DBFIRST.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string? PaymentMethodName { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
