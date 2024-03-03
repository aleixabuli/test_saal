using Application.FoodDelivery.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;

namespace Infra.FoodDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGetAllProductsUseCase _getAllProductsUseCase;

        public ProductsController(IGetAllProductsUseCase getAllProductsUseCase)
        {
            _getAllProductsUseCase = getAllProductsUseCase;
        }

        /// <summary>
        /// This method return all the products of the catalog/>
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var orderOptionsList = await _getAllProductsUseCase.Execute();
            return Ok(orderOptionsList);
        }
    }
}
