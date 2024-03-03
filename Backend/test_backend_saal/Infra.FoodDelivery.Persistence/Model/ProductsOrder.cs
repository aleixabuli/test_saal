using System;
using System.Collections.Generic;

namespace Infra.FoodDelivery.Persistence.Model;

public partial class ProductsOrder
{
    public int Id { get; set; }

    public int DeliveryOrderId { get; set; }

    public int ProductId { get; set; }

    public virtual DeliveryOrder DeliveryOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
