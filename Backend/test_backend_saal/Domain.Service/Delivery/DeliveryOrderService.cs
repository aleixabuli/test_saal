using Domain.Model.Delivery;
using Domain.Model.Delivery.Enums;
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

        public async Task<bool> GoToNextStep(int orderId)
        {
            var deliveryOrder = await _deliveryOrderRepository.GetDeliveryOrderById(orderId);
            var lastStep = Enum.GetValues(typeof(DeliveryEnums.OrderStatus)).Cast<DeliveryEnums.OrderStatus>().Max();

            if (deliveryOrder == null || deliveryOrder.OrderStatus == (int)lastStep)
            {
                return false;
            }
            else
            {
                bool result = await _deliveryOrderRepository.GoToNextStep(orderId);
                return result;
            }
        }
    }
}
