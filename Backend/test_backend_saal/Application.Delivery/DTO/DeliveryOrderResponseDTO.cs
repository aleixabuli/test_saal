using System.Text.Json.Serialization;

namespace Application.FoodDelivery.DTO
{
    public class DeliveryOrderResponseDTO
    {
        [JsonPropertyName(nameof(Id))]
        public int Id { get; set; }

        [JsonPropertyName(nameof(ClientName))]
        public string ClientName { get; set; }

        [JsonPropertyName(nameof(ClientSurname))]
        public string ClientSurname { get; set; }

        [JsonPropertyName(nameof(Direction))]
        public string Direction { get; set; }

        [JsonPropertyName(nameof(City))]
        public string City { get; set; }

        [JsonPropertyName(nameof(Country))]
        public string Country { get; set; }

        [JsonPropertyName(nameof(PayOption))]
        public int PayOption { get; set; }

        [JsonPropertyName(nameof(TotalToPay))]
        public decimal TotalToPay { get; set; }

        [JsonPropertyName(nameof(OrderStatus))]
        public int OrderStatus { get; set; }
    }
}
