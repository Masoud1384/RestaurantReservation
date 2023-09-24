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
        public int userId { get; set; }
        public int restaurantid { get; set; }
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

        public CreateReservationCommand(int numberOfGuests, DateTime reservationTime, string specialRequests, ReservationStatus reservationStatus, int user, int restaurant) : this(numberOfGuests, reservationTime, specialRequests, reservationStatus)
        {
            this.userId = user;
            this.restaurantid = restaurant;
        }
    }
}
