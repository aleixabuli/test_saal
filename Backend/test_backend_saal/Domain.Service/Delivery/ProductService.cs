using Domain.Model.Delivery;
using Domain.Repository.Contracts.FoodDelivery;
using Domain.Service.Contracts.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Delivery
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDomainModel>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products;
        }
    }
}
