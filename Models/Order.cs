using System;
using System.Collections.Generic;

namespace ProductCRUD.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int? Userid { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
