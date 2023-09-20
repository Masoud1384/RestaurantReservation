using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IRestaurantRepository : IRepository<int, Restaurant>
    {
        Restaurant FindRestaurant(Expression<Func<Restaurant, bool>> expression);
        List<Restaurant> Ingredients(Expression<Func<Restaurant, bool>> expression);
        bool Update(Restaurant restaurant);
    }
}
