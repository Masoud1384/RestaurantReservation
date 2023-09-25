using BusinessLogicLayer.Commands.Reservation;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.IServices
{
    public interface IReservationService
    {
        ReservationViewModel GetReservation(int id);
        List<ReservationViewModel> GetReservations();
        bool ReservationExists(Expression<Func<ReservationViewModel, bool>> expression);
        List<ReservationViewModel> GetReservations(Expression<Func<ReservationViewModel, bool>> expression);
        bool CreateReservation(CreateReservationCommand reservation,out int id);
        bool UpdateReservation(UpdateReservationCommand reservation);
        bool DeleteReservation(int id);
    }
}
