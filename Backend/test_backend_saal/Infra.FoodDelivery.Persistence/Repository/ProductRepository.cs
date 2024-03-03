using AutoMapper;
using Domain.Model.Delivery;
using Domain.Repository.Contracts.FoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.FoodDelivery.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductDomainModel>> GetAllProducts()
        {
            var products = new List<object>();

            var productsDomain = _mapper.Map<List<ProductDomainModel>>(products);

            return productsDomain;
        }
    }
}
