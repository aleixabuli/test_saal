using Application.FoodDelivery.DTO;
using Application.FoodDelivery.UseCaseContracts;
using AutoMapper;
using Domain.Model.Delivery;
using Domain.Service.Contracts.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoodDelivery.UseCase
{
    public class CreateDeliveryOrderUseCase : ICreateDeliveryOrderUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryOrderService _deliveryOrderService;

        public CreateDeliveryOrderUseCase(
            IMapper mapper,
            IDeliveryOrderService deliveryOrderService
            )
        {
            _mapper = mapper;
            _deliveryOrderService = deliveryOrderService;
        }

        public async Task<int> Execute(CreateDeliveryOrderInput createDeliveryOrderInput)
        {
            var deliveryOrderModel = _mapper.Map<DeliveryOrderDomainModel>(createDeliveryOrderInput.deliveryOrder);
            var productIdAndQtList = _mapper.Map<List<ProductIdAndQtDomainModel>>(createDeliveryOrderInput.productIdAndQtList);
            
            var orderId = await _deliveryOrderService.CreateOrder(
                deliveryOrderModel, 
                productIdAndQtList
                );

            return orderId;
        }
    }
}
