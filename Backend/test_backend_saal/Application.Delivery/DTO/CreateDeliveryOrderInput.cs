using System.ComponentModel.DataAnnotations;

namespace Application.FoodDelivery.DTO
{
    public class CreateDeliveryOrderInput
    {
        [Required]
        public DeliveryOrderDTO deliveryOrder { get; set; }

        [Required]
        public List<ProductIdAndQtDTO> productIdAndQtList { get; set; }
    }
}
