using Application.FoodDelivery.DTO;

namespace Application.FoodDelivery.UseCaseContracts
{
    public interface IGetDeliveryOrderByIdUseCase
    {
        Task<DeliveryOrderDTO> Execute(int orderId);
    }
}
