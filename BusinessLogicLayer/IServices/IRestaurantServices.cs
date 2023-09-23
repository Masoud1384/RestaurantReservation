using BusinessLogicLayer.Commands.Restaurant;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.IServices
{
    public interface IRestaurantServices
    {
        Restaurant GetRestaurant(int id);
        List<Restaurant> GetRestaurants();
        bool RestaurantExists(Expression<Func<Restaurant, bool>> expression);
        Restaurant FindRestaurant(int id);
        void CreateRestaurant(Restaurant restaurant);
        List<Restaurant> GetRestaurants(Expression<Func<RestaurantViewModel, bool>> expression);
        bool UpdateRestaurant(Restaurant restaurant);
    }
}
