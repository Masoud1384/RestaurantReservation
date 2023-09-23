using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IReservationRepository : IRepository<int, Reservation>
    {
        Reservation FindUser(int id);
        List<Reservation> Reservations(Expression<Func<Reservation, bool>> expression);
        bool Update(Reservation reservation);
    }
}
