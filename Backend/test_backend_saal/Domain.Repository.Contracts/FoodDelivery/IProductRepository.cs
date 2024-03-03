using Domain.Model.Delivery;

namespace Domain.Repository.Contracts.FoodDelivery
{
    public interface IProductRepository
    {
        Task<List<ProductDomainModel>> GetAllProducts();
    }
}
