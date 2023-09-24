using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reservationService.GetReservations());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _reservationService.FindUser(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationCommand createReservation)
        {
            return _reservationService.CreateReservation(createReservation);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
