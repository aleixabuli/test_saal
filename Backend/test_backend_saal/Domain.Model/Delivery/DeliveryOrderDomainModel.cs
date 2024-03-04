namespace Domain.Model.Delivery
{
    public class DeliveryOrderDomainModel
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PayOption { get; set; }
        public decimal TotalToPay { get; set; }
        public int OrderStatus { get; set; }
    }
}
