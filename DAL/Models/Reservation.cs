
namespace DataAccessLayer.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationTime { get; set; }
        public string SpecialRequests { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        public Reservation()
        {
            
        }
        public Reservation(int numberOfGuests, DateTime reservationTime, string specialRequests, ReservationStatus reservationStatus, User user, Restaurant restaurant)
        {
            NumberOfGuests = numberOfGuests;
            ReservationTime = reservationTime;
            SpecialRequests = specialRequests;
            this.reservationStatus = reservationStatus;
            User = user;
            Restaurant = restaurant;
        }
        public Reservation(int numberOfGuests, DateTime reservationTime, string specialRequests, ReservationStatus reservationStatus, int userId, int restaurantId)
        {
            NumberOfGuests = numberOfGuests;
            ReservationTime = reservationTime;
            SpecialRequests = specialRequests;
            this.reservationStatus = reservationStatus;
            UserId = userId;
            RestaurantId = restaurantId;
        }
    }
    public enum ReservationStatus
    {
        Reserved,
        Canceled,
        Processing
    }
}
