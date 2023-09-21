using DataAccessLayer.Models;

namespace BusinessLogicLayer.Commands.Reservation
{
    public class CreateReservationCommand
    {
        public int NumberOfGuests { get; set; }
        public DateTime ReservationTime { get; set; }
        public string SpecialRequests { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public DataAccessLayer.Models.User user { get; set; }
        public DataAccessLayer.Models.Restaurant restaurant { get; set; }
    }
}
