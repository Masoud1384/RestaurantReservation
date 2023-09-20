using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IReservationRepository : IRepository<int, Reservation>
    {
        Reservation FindUser(Expression<Func<Reservation, bool>> expression);
        List<Reservation> Ingredients(Expression<Func<Reservation, bool>> expression);
        bool Update(Reservation reservation);
    }
}
