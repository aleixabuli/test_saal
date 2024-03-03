using System;
using System.Collections.Generic;

namespace Infra.FoodDelivery.Persistence.Model;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? UrlImage { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
