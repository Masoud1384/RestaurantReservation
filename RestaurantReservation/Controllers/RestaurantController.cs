using BusinessLogicLayer.Commands.Restaurant;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
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
            var result = _restaurantServices.GetRestaurants();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _restaurantServices.FindRestaurant(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateRestaurantCommand restaurantCommand)
        {
            var result = _restaurantServices.CreateRestaurant(restaurantCommand);
            if (result > 0)
            {
                string url = Url.Action(nameof(Get), "Reservation", new { Id = result }, Request.Scheme);
                return Ok(url);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public void Put([FromBody] UpdateRestaurantCommand value)
        {


        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
