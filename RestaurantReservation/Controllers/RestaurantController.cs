using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;


namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _restaurantServices;

        public RestaurantController(IRestaurantServices restaurantServices)
        {
            _restaurantServices = restaurantServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_restaurantServices.GetRestaurants());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _restaurantServices.FindRestaurant(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] )
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
