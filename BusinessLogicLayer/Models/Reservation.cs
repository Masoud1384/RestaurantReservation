namespace RestaurantReservation
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationTime { get; set; }
        public string SpecialRequests { get; set; }
    }

}
