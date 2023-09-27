using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantReservation.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : V1.UserController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration) : base(userService)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("{username},{email}")]
        public virtual IActionResult Post(string username, string email)
        {
            var createUserCommand = new CreateUserCommand()
            {
                Email = email,
                Name = username,
            };
            var userId = _userService.CreateUser(createUserCommand);
            if (userId != -1)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                var Claims = new List<Claim>
                {
                    new Claim("Username",createUserCommand.Name),
                    new Claim("UserId",userId.ToString())
                };
                var tokenJwt = new JwtSecurityToken(
                    issuer: _configuration["JWT:issuer"],
                    audience: _configuration["JWT:audience"],
                    claims: Claims,
                    expires: DateTime.Now.AddDays(15),
                    notBefore: DateTime.Now,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );
                var token = new JwtSecurityTokenHandler().WriteToken(tokenJwt);
                var url = Url.Action(nameof(Get), "User", new { id = userId }, Request.Scheme);
                return Created(url, userId);
            }
            return BadRequest();
        }
    }
}
