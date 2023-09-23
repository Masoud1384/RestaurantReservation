using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IRestaurantRepository : IRepository<int, Restaurant>
    {
        Restaurant FindRestaurant(int id);
        List<Restaurant> Restaurants(Expression<Func<Restaurant, bool>> expression);
        bool Update(Restaurant restaurant);
    }
}
