using DataAccessLayer.Models;

namespace BusinessLogicLayer.Commands.Reservation
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationTime { get; set; }
        public string SpecialRequests { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public int restaurantId { get; set; }
        public int userId { get; set; }
    }
}
