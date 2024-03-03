using System;
using System.Collections.Generic;

namespace Infra.FoodDelivery.Persistence.Model;

public partial class DeliveryOrder
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientSurname { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public sbyte PayOption { get; set; }

    public decimal TotalToPay { get; set; }

    public virtual ICollection<ProductsOrder> ProductsOrders { get; set; } = new List<ProductsOrder>();
}
