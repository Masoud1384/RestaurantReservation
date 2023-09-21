using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class RestaurantService
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant FindRestaurant(Expression<Func<Restaurant, bool>> expression)
        {
            return _restaurantRepository.FindRestaurant(expression);
        }

        public List<Restaurant> GetRestaurants(Expression<Func<Restaurant, bool>> expression)
        {
            return _restaurantRepository.Ingredients(expression);
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            return _restaurantRepository.Update(restaurant);
        }
    }

}
