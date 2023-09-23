using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation GetReservation(int id)
        {
            return _reservationRepository.Get(id);
        }

        public List<Reservation> GetReservations()
        {
            return _reservationRepository.Get();
        }

        public void CreateReservation(Reservation reservation)
        {
            _reservationRepository.Create(reservation);
            _reservationRepository.SaveChanges();
        }

        public bool ReservationExists(Expression<Func<Reservation, bool>> expression)
        {
            return _reservationRepository.Exists(expression);
        }

        public Reservation FindUser(int id)
        {
            return _reservationRepository.FindUser(id);
        }

        public List<Reservation> GetReservations(Expression<Func<Reservation, bool>> expression)
        {
            return _reservationRepository.Reservations(expression);
        }

        public bool UpdateReservation(Reservation reservation)
        {
            return _reservationRepository.Update(reservation);
        }
    }
}
