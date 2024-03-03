using Application.FoodDelivery.DTO;
using Application.FoodDelivery.UseCaseContracts;
using AutoMapper;
using Domain.Service.Contracts.Delivery;

namespace Application.FoodDelivery.UseCase
{
    public class GetAllProductsUseCase : IGetAllProductsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _foodDeliveryService;

        public GetAllProductsUseCase(
            IMapper mapper,
            IProductService foodDeliveryService
            )
        {
            _mapper = mapper;
            _foodDeliveryService = foodDeliveryService;
        }

        public async Task<List<ProductResponse>> Execute()
        {
            var productsList = await _foodDeliveryService.GetAllProducts();

            var orderOptionsListResponse = _mapper.Map<List<ProductResponse>>(productsList);
            return orderOptionsListResponse;
        }
    }
}
