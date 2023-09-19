using RestaurantReservation;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public interface IReservationRepository : IRepository<int, Reservation>
    {
        Reservation FindUser(Expression<Func<Reservation, bool>> expression);
        List<Reservation> Ingredients(Expression<Func<Reservation, bool>> expression);
        void Update(Reservation recipeRating);
    }
}
