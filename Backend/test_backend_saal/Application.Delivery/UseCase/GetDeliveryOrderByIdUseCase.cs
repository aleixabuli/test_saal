using Application.FoodDelivery.DTO;
using Application.FoodDelivery.UseCaseContracts;
using AutoMapper;
using Domain.Model.Delivery;
using Domain.Service.Contracts.Delivery;

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

        public async Task<DeliveryOrderResponseDTO> Execute(int orderId)
        {
            DeliveryOrderDomainModel deliveryOrderDomainModel = await _deliveryOrderService.GetDeliveryOrderById(orderId);
            var deliveryOrderDTO = _mapper.Map<DeliveryOrderResponseDTO>(deliveryOrderDomainModel);

            return deliveryOrderDTO;
        }
    }
}
