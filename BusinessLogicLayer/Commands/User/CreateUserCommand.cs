using BusinessLogicLayer.Commands.Reservation;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Commands.User
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<ReservationViewModel>? Reservations { get; set; }

        public CreateUserCommand() { }

        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public CreateUserCommand(string name, string email, List<CreateReservationCommand>? reservations) : this(name, email)
        {
            Reservations = reservations.Select(r=> 
            new ReservationViewModel
            {
                NumberOfGuests = r.NumberOfGuests,
                ReservationTime = r.ReservationTime,
                restaurantId = r.restaurantid,
                SpecialRequests = r.SpecialRequests,
                reservationStatus = (ReservationStatus)r.reservationStatus,
            }).ToList();
        }
    }
}
