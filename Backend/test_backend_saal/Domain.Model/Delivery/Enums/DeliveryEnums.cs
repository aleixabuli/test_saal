namespace Domain.Model.Delivery.Enums
{
    public static class DeliveryEnums
    {
        public enum PayOption
        {
            ByCash = 1,
            ByCard = 2
        }

        public enum OrderStatus 
        {
            Preparing = 1,
            GoingToDestination = 2,
            Delivered = 3,
        }
    }
}
