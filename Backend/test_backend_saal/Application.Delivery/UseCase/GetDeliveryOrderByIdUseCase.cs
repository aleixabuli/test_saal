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
    public class GetDeliveryOrderByIdUseCase : IGetDeliveryOrderByIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryOrderService _deliveryOrderService;

        public GetDeliveryOrderByIdUseCase(
            IMapper mapper,
            IDeliveryOrderService deliveryOrderService
            )
        {
            _mapper = mapper;
            _deliveryOrderService = deliveryOrderService;
        }

        public async Task<DeliveryOrderDTO> Execute(int orderId)
        {
            DeliveryOrderDomainModel deliveryOrderDomainModel = await _deliveryOrderService.GetDeliveryOrderById(orderId);
            var deliveryOrderDTO = _mapper.Map<DeliveryOrderDTO>(deliveryOrderDomainModel);

            return deliveryOrderDTO;
        }
    }
}
