using BusinessLogicLayer;
using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _userService.GetUsers()
                .Select(r => new UserViewModel
                {
                    Email = r.Email,
                    id = r.id,
                    Name = r.Email,
                    Reservations = r.Reservations,
                    links = r.links = new List<ApiLink>
                {
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Get),"User",new {id = r.id },Request.Scheme),
                        Relationship = "Self",
                        Method = "Get"
                    },
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Delete),"User",new {id = r.id},Request.Scheme),
                        Relationship = "Delete",
                        Method = "Delete"
                    },
                }});
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetUser(id);
            if (result.id != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromQuery] CreateUserCommand createUserCommand)
        {
            var userId = _userService.CreateUser(createUserCommand);
            if (userId != -1)
            {
                var url = Url.Action(nameof(Get), "User", new { id = userId }, Request.Scheme);
                return Created(url, userId);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserCommand userCmd)
        {
            int result = 0;
            if (!_userService.UserExists(r => r.id == userCmd.Id))
            {
                var create = new CreateUserCommand(userCmd.Name, userCmd.Email);
                result = _userService.CreateUser(create);
            }
            else
            {
                _userService.UpdateUser(userCmd);
                result = userCmd.Id;
            }
            string url = Url.Action(nameof(Get), "Reservation", new { Id = result }, Request.Scheme);
            return Ok(url);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result)
                return Ok();

            return NotFound();
        }
    }
}
