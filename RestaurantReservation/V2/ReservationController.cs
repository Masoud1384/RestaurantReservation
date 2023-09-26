using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReservationController : V1.ReservationController
    {
        public ReservationController(IReservationService reservationService) : base(reservationService)
        {
        }
    }
}
