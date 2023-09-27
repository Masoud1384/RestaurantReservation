using BusinessLogicLayer;
using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.V1
{
    [ApiVersion("1.0")]
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
        public virtual IActionResult Get()
        {
            var result = _reservationService.GetReservations().
                Select(r =>
                new ReservationViewModel
                {
                    reservationStatus = r.reservationStatus,
                    links = new List<ApiLink>
                {
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Get),"Reservation",new {id = r.Id },Request.Scheme),
                        Relationship = "Self",
                        Method = "Get"
                    },
                    new ApiLink
                    {
                        Hrref = Url.Action(nameof(Delete),"Reservation",new {id = r.Id },Request.Scheme),
                        Relationship = "Delete",
                        Method = "Delete"
                    },
                   },
                    Id = r.Id,
                    NumberOfGuests = r.NumberOfGuests,
                    ReservationTime = r.ReservationTime,
                    restaurantId = r.restaurantId,
                    SpecialRequests = r.SpecialRequests,
                    userId = r.userId
                });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var user = _reservationService.GetReservation(id);
            return Ok(user);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] CreateReservationCommand reservationCommand)
        {
            int id = 0;
            var result = _reservationService.CreateReservation(reservationCommand, out id);
            if (result && id > 0)
            {
                string url = Url.Action(nameof(Get), "Reservation", new { Id = id }, Request.Scheme);
                return Ok(url);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody] UpdateReservationCommand reservationCommand)
        {
            int id = 0;
            if (!_reservationService.ReservationExists(r => r.Id == reservationCommand.Id))
            {
                var create = new CreateReservationCommand(reservationCommand.NumberOfGuests, reservationCommand.ReservationTime, reservationCommand.SpecialRequests, reservationCommand.reservationStatus);
                var result = _reservationService.CreateReservation(create, out id);
            }
            else
            {
                var result = _reservationService.UpdateReservation(reservationCommand);
            }
            string url = Url.Action(nameof(Get), "Reservation", new { Id = id }, Request.Scheme);
            return Ok(url);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            if (_reservationService.ReservationExists(r => r.Id == id))
            {
                _reservationService.DeleteReservation(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
