using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : V1.UserController
    {
        public UserController(IUserService userService) : base(userService)
        {
        }
        
    }
}
