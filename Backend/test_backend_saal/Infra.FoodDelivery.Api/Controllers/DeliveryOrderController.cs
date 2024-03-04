using Application.FoodDelivery.DTO;
using Application.FoodDelivery.UseCase;
using Application.FoodDelivery.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;

namespace Infra.FoodDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryOrderController : ControllerBase
    {
        private readonly ICreateDeliveryOrderUseCase _createDeliveryOrderUseCase;
        private readonly IGetDeliveryOrderByIdUseCase _getDeliveryOrderByIdUseCase;

        public DeliveryOrderController(
            ICreateDeliveryOrderUseCase createDeliveryOrderUseCase,
            IGetDeliveryOrderByIdUseCase getDeliveryOrderByIdUseCase
            )
        {
            _createDeliveryOrderUseCase = createDeliveryOrderUseCase;
            _getDeliveryOrderByIdUseCase = getDeliveryOrderByIdUseCase;
        }

        /// <summary>
        /// Creates a DeliveryOrder given the data related with the client and the products of the order
        /// </summary>
        /// <param name="deliveryOrders"></param>
        /// <returns></returns>
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody]CreateDeliveryOrderInput deliveryOrders)
        {
            var orderId = await _createDeliveryOrderUseCase.Execute(deliveryOrders);
            return Ok(orderId);
        }

        /// <summary>
        /// Gets the order given an Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("GetDeliveryOrderById")]
        public async Task<IActionResult> GetDeliveryOrderById([FromQuery] int orderId)
        {
            var deliveryOrder = await _getDeliveryOrderByIdUseCase.Execute(orderId);
            return Ok(deliveryOrder);
        }
    }
}
