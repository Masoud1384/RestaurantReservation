using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IEnumerable<UserViewModel> Get()
        {
            return _userService.GetUsers();
        }

        // GET api/<USerController>/5
        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public IActionResult Post([FromQuery] string email, string name)
        {
            var userId = _userService.CreateUser(new CreateUserCommand
            {
                Email = email,
                Name = name,
            });
            if (userId != -1)
            {
                var url = Url.Action(nameof(Get), "User", new { id = userId }, Request.Scheme);
                return Created(url, userId);
            }
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserCommand userCmd)
        {
            bool isSuccesed = false;
            isSuccesed = _userService.UpdateUser(new UpdateUserCommand
            {
                Email = userCmd.Email,
                Id = userCmd.Id,
                Name = userCmd.Name,
                Reservations = userCmd.Reservations
            });
            int id = 0;
            if (!isSuccesed)
            {
                var createcmd = new CreateUserCommand
                {
                    Email = userCmd.Email,
                    Name = userCmd.Name,
                };
                id = _userService.CreateUser(createcmd);
            }
            if (id != -1)
                return Ok();

            return BadRequest();
        }

        // DELETE api/<UserController>/5
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
