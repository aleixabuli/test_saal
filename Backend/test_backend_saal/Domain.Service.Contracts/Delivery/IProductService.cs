using Domain.Model.Delivery;

namespace Domain.Service.Contracts.Delivery
{
    public interface IProductService
    {
        Task<List<ProductDomainModel>> GetAllProducts();
    }
}
