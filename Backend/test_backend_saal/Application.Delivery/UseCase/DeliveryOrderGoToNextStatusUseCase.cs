using Application.FoodDelivery.UseCaseContracts;
using Domain.Service.Contracts.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoodDelivery.UseCase
{
    public class DeliveryOrderGoToNextStatusUseCase : IDeliveryOrderGoToNextStatusUseCase
    {
        private readonly IDeliveryOrderService _deliveryOrderService;

        public DeliveryOrderGoToNextStatusUseCase(IDeliveryOrderService deliveryOrderService)
        {
            _deliveryOrderService = deliveryOrderService;
        }

        public async Task<bool> Execute(int orderId)
        {
            return await _deliveryOrderService.GoToNextStep(orderId);
        }
    }
}
