using RestaurantReservation;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public interface IRestaurantRepository : IRepository<int, Restaurant>
    {
        Restaurant FindRestaurant(Expression<Func<Restaurant, bool>> expression);
        List<Restaurant> Ingredients(Expression<Func<Restaurant, bool>> expression);
        void Update(Restaurant recipeRating);
    }
}
