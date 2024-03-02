using Microsoft.AspNetCore.Mvc;

namespace Infra.FoodDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
            
        }

        /// <summary>
        /// This method is created for testing
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            string[] array = { "test1", "test2", "test3" };
            return Ok(array);
        }
    }
}
