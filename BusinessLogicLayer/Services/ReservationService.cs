using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class ReservationService
    {
        private IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation FindUser(Expression<Func<Reservation, bool>> expression)
        {
            return _reservationRepository.FindUser(expression);
        }

        public List<Reservation> GetReservations(Expression<Func<Reservation, bool>> expression)
        {
            return _reservationRepository.Ingredients(expression);
        }

        public bool UpdateReservation(Reservation reservation)
        {
            return _reservationRepository.Update(reservation);
        }
    }
}
