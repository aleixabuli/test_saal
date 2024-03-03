using Application.FoodDelivery.DTO;
using AutoMapper;
using Domain.Model.Delivery;

namespace Application.FoodDelivery.Mapping
{
    public class FoodDeliveryMapper : Profile
    {
        public FoodDeliveryMapper()
        {
            CreateMap<ProductDomainModel, ProductResponse>();
            CreateMap<ProductResponse, ProductDomainModel>();
        }
    }
}
