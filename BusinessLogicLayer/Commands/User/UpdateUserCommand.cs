using BusinessLogicLayer.Commands.Reservation;

namespace BusinessLogicLayer.Commands.User
{
    public class UpdateUserCommand : CreateUserCommand
    {
        public int Id { get; set; }
        protected List<UpdateReservationCommand>? Reservations { get; set; }

    }
}
