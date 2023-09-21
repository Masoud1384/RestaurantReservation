using BusinessLogicLayer.Commands.Restaurant;
using BusinessLogicLayer.Commands.User;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Commands.Reservation
{
    public class CreateReservationCommand
    {
        public int NumberOfGuests { get; set; }
        public DateTime ReservationTime { get; set; }
        public string SpecialRequests { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public CreateUserCommand user { get; set; }
        public CreateRestaurantCommand restaurant { get; set; }
        public CreateReservationCommand()
        {
            
        }
        public CreateReservationCommand(int numberOfGuests, DateTime reservationTime, string specialRequests, ReservationStatus reservationStatus)
        {
            NumberOfGuests = numberOfGuests;
            ReservationTime = reservationTime;
            SpecialRequests = specialRequests;
            this.reservationStatus = reservationStatus;
        }

        public CreateReservationCommand(int numberOfGuests, DateTime reservationTime, string specialRequests, ReservationStatus reservationStatus, CreateUserCommand user, CreateRestaurantCommand restaurant) : this(numberOfGuests, reservationTime, specialRequests, reservationStatus)
        {
            this.user = user;
            this.restaurant = restaurant;
        }
    }
}
