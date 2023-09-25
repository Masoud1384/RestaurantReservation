using BusinessLogicLayer;
using BusinessLogicLayer.Commands.Reservation;
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
            var result = _restaurantServices.GetRestaurants()
                .Select(r => r.links = new List<ApiLink>
                {
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Get),"Reservation",new {id = r.id },Request.Scheme),
                        Relationship = "Self",
                        Method = "Get"
                    },
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Delete),"Reservation",new {id = r.id},Request.Scheme),
                        Relationship = "Delete",
                        Method = "Delete"
                    },
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Put),"Reservation",Request.Scheme),
                        Relationship = "Update",
                        Method = "Put"
                    },
                }); ;
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
        public IActionResult Put([FromBody] UpdateRestaurantCommand value)
        {
            int id = 0;
            if (!_restaurantServices.RestaurantExists(r => r.id == value.Id))
            {
                var create = new CreateRestaurantCommand(value.Name
                    , value.OpeningHours,value.NumberOfTables,value.address,value.city,value.phonenumber);
                id = _restaurantServices.CreateRestaurant(create);
            }
            else
            {
                _restaurantServices.UpdateRestaurant(value);
                id = value.Id;
            }
            string url = Url.Action(nameof(Get), "Reservation", new { Id = id }, Request.Scheme);
            return Ok(url);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_restaurantServices.RestaurantExists(r => r.id == id))
            {
                _restaurantServices.DeleteRestaurant(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
