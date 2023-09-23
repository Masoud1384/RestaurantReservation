using DataAccessLayer.Models;

namespace BusinessLogicLayer.IServices
{
    public interface IReservationService
    {
        Reservation GetReservation(int id);

    }
}
