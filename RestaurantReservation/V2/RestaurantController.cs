using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RestaurantController : V1.RestaurantController
    {
        public RestaurantController(IRestaurantServices restaurantServices) : base(restaurantServices)
        {
        }
    }
}
