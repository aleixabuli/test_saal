using System.Text.Json.Serialization;

namespace Application.FoodDelivery.DTO
{
    
    public class ProductDTO
    {
        [JsonPropertyName(nameof(Id))]
        public int Id { get; set; }

        [JsonPropertyName(nameof(Name))]
        public string Name { get; set; }

        [JsonPropertyName(nameof(UrlImage))]
        public string UrlImage { get; set; }

        [JsonPropertyName(nameof(Price))]
        public decimal Price { get; set; }
    }
}
