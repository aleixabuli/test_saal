using Application.FoodDelivery.DTO;

namespace Application.FoodDelivery.UseCaseContracts
{
    public interface IGetDeliveryOrderByIdUseCase
    {
        Task<DeliveryOrderResponseDTO> Execute(int orderId);
    }
}
