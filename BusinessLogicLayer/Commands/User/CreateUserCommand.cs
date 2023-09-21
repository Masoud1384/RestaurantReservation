using BusinessLogicLayer.Commands.Reservation;

namespace BusinessLogicLayer.Commands.User
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CreateReservationCommand>? Reservations { get; set; }
    }
}
