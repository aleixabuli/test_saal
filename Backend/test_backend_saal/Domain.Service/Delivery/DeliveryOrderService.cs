using Domain.Model.Delivery;
using Domain.Repository.Contracts.FoodDelivery;
using Domain.Service.Contracts.Delivery;

namespace Domain.Service.Delivery
{
    public class DeliveryOrderService : IDeliveryOrderService
    {
        private readonly IDeliveryOrderRepository _deliveryOrderRepository;

        public DeliveryOrderService(IDeliveryOrderRepository deliveryOrderRepository)
        {
            _deliveryOrderRepository = deliveryOrderRepository;
        }

        public async Task<int> CreateOrder(
            DeliveryOrderDomainModel deliveryOrderDomainModel,
            List<ProductIdAndQtDomainModel> productIdAndQtDomainModelList
            )
        {
            deliveryOrderDomainModel.OrderStatus = 1;
            var orderId = await _deliveryOrderRepository.CreateDeliveryOrder(
                deliveryOrderDomainModel,
                productIdAndQtDomainModelList
                );

            return orderId;
        }

        public async Task<DeliveryOrderDomainModel> GetDeliveryOrderById(int orderId)
        {
            var deliveryOrderDomainModel = await _deliveryOrderRepository.GetDeliveryOrderById(orderId);

            return deliveryOrderDomainModel;
        }
    }
}
