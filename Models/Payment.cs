using System;
using System.Collections.Generic;

namespace ProductCRUD.Models;

public partial class Payment
{
    public int Paymentid { get; set; }

    public int? Orderid { get; set; }

    public DateTime? Paymentdate { get; set; }

    public decimal? Amount { get; set; }

    public string? Paymentmethod { get; set; }

    public virtual Order? Order { get; set; }
}
