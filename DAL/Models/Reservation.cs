
namespace DataAccessLayer.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationTime { get; set; }
        public string SpecialRequests { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
    }
    public enum ReservationStatus
    {
        Reserved,
        Canceled,
        Processing
    }
}
