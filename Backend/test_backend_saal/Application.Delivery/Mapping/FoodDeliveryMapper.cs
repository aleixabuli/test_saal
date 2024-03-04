using Application.FoodDelivery.DTO;
using AutoMapper;
using Domain.Model.Delivery;

namespace Application.FoodDelivery.Mapping
{
    public class FoodDeliveryMapper : Profile
    {
        public FoodDeliveryMapper()
        {
            CreateMap<ProductDomainModel, ProductDTO>();
            CreateMap<ProductDTO, ProductDomainModel>();

            CreateMap<DeliveryOrderDTO, DeliveryOrderDomainModel>();
            CreateMap<DeliveryOrderDomainModel, DeliveryOrderDTO>();

            CreateMap<ProductIdAndQtDTO, ProductIdAndQtDomainModel>();
            CreateMap<ProductIdAndQtDomainModel, ProductIdAndQtDTO>();
        }
    }
}
