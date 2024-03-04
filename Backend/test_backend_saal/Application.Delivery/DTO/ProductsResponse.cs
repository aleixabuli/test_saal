namespace Application.FoodDelivery.DTO
{
    public class ProductsResponse
    {
        public ProductsResponse(List<ProductDTO> productsArray)
        {
            this.productsArray = productsArray;
        }
        public List<ProductDTO> productsArray { get; set; }
    }
}
