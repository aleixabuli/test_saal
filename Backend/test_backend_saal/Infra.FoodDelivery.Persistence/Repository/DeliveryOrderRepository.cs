using AutoMapper;
using Domain.Model.Delivery;
using Domain.Repository.Contracts.FoodDelivery;
using Infra.FoodDelivery.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace Infra.FoodDelivery.Persistence.Repository
{
    public class DeliveryOrderRepository : IDeliveryOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryContext _foodDeliveryContext;

        public DeliveryOrderRepository(
            IMapper mapper,
            FoodDeliveryContext foodDeliveryContext
            )
        {
            _mapper = mapper;
            _foodDeliveryContext = foodDeliveryContext;
        }

        public async Task<int> CreateDeliveryOrder(
            DeliveryOrderDomainModel deliveryOrderDomainModel,
            List<ProductIdAndQtDomainModel> productIdAndQtList
            )
        {
            int orderId = 0;
            try
            {
                var deliveryOrderToCreate = _mapper.Map<DeliveryOrder>(deliveryOrderDomainModel);
                _foodDeliveryContext.DeliveryOrders.Add(deliveryOrderToCreate);
                await _foodDeliveryContext.SaveChangesAsync();

                orderId = deliveryOrderToCreate.Id;

                foreach (var product in productIdAndQtList)
                {
                    var productsOrdersToCreate = new ProductsOrder()
                    {
                        ProductId = product.id,
                        DeliveryOrderId = orderId,
                        ProductQuantity = product.quantity,
                    };
                    _foodDeliveryContext.ProductsOrders.Add(productsOrdersToCreate);
                }

                await _foodDeliveryContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return orderId;
        }

        public async Task<DeliveryOrderDomainModel> GetDeliveryOrderById(int orderId)
        {
            var deliveryOrder = await _foodDeliveryContext.DeliveryOrders
                .Where(d => d.Id == orderId)
                .FirstOrDefaultAsync();

            var deliveryOrderDomain = _mapper.Map<DeliveryOrderDomainModel>(deliveryOrder);

            return deliveryOrderDomain;
        }

        public async Task<bool> GoToNextStep(int orderId)
        {
            var deliveryOrder = await _foodDeliveryContext.DeliveryOrders
                .Where(d => d.Id == orderId)
                .FirstOrDefaultAsync();

            if (deliveryOrder == null)
            {
                throw new Exception($"Does not exists a {nameof(DeliveryOrder)} with the Id {orderId}.");
            }

            deliveryOrder.OrderStatus++;
            await _foodDeliveryContext.SaveChangesAsync();

            return true;
        }
    }
}
