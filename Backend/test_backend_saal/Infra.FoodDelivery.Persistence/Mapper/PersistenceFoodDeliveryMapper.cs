using AutoMapper;
using Domain.Model.Delivery;
using Infra.FoodDelivery.Persistence.Model;

namespace Infra.FoodDelivery.Persistence.Mapper
{
    public class PersistenceFoodDeliveryMapper : Profile
    {
        public PersistenceFoodDeliveryMapper()
        {
            CreateMap<Product, ProductDomainModel>();
            CreateMap<ProductDomainModel, Product>();

            CreateMap<DeliveryOrder, DeliveryOrderDomainModel>();
            CreateMap<DeliveryOrderDomainModel, DeliveryOrder>();

        }
    }
}
