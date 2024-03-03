using AutoMapper;
using Domain.Model.Delivery;
using Domain.Repository.Contracts.FoodDelivery;
using Infra.FoodDelivery.Persistence.Model;
using Microsoft.EntityFrameworkCore;
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
        private readonly FoodDeliveryContext _foodDeliveryContext;

        public ProductRepository(
            IMapper mapper,
            FoodDeliveryContext foodDeliveryContext
            )
        {
            _mapper = mapper;
            _foodDeliveryContext = foodDeliveryContext;
        }

        public async Task<List<ProductDomainModel>> GetAllProducts()
        {
            var products = await _foodDeliveryContext.Products.ToListAsync();

            var productsDomain = _mapper.Map<List<ProductDomainModel>>(products);

            return productsDomain;
        }
    }
}
