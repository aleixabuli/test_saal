using Domain.Model.Delivery;

namespace Domain.Service.Contracts.Delivery
{
    public interface IDeliveryOrderService
    {
        Task<int> CreateOrder(
            DeliveryOrderDomainModel deliveryOrderDomainModel,
            List<ProductIdAndQtDomainModel> productIdAndQtDomainModelList
            );

        Task<DeliveryOrderDomainModel> GetDeliveryOrderById(int orderId);
    }
}
