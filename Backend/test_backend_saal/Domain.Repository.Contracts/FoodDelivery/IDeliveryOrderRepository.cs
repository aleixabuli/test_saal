using Domain.Model.Delivery;

namespace Domain.Repository.Contracts.FoodDelivery
{
    public interface IDeliveryOrderRepository
    {
        Task<int> CreateDeliveryOrder(
            DeliveryOrderDomainModel deliveryOrderDomainModel,
            List<ProductIdAndQtDomainModel> productIdAndQtList
            );

        Task<DeliveryOrderDomainModel> GetDeliveryOrderById(int orderId);

        Task<bool> GoToNextStep(int orderId);
    }
}
