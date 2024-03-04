using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.FoodDelivery.DTO
{
    public class DeliveryOrderDTO
    {
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
