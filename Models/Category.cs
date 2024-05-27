using System;
using System.Collections.Generic;

namespace ProductCRUD.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string? Catergoryname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
