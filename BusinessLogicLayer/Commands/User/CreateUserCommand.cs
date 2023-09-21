using BusinessLogicLayer.Commands.Reservation;

namespace BusinessLogicLayer.Commands.User
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CreateReservationCommand>? Reservations { get; set; }

        public CreateUserCommand() { }

        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public CreateUserCommand(string name, string email, List<CreateReservationCommand>? reservations) : this(name, email)
        {
            Reservations = reservations;
        }
    }
}
