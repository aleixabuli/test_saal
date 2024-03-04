namespace Application.FoodDelivery.UseCaseContracts
{
    public interface IDeliveryOrderGoToNextStatusUseCase
    {
        Task<bool> Execute(int orderId);
    }
}
