using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.IServices
{
    public interface IReservationService
    {
        Reservation GetReservation(int id);
        List<Reservation> GetReservations();
        bool ReservationExists(Expression<Func<Reservation, bool>> expression);
        Reservation FindUser(int id);
        List<Reservation> GetReservations(Expression<Func<Reservation, bool>> expression);
        void CreateReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);
    }
}
