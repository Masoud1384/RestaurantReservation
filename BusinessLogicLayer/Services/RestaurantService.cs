using BusinessLogicLayer.Commands.Restaurant;
using BusinessLogicLayer.Commands.User;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class RestaurantService : IRestaurantServices
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant GetRestaurant(int id) 
        {
            return _restaurantRepository.Get(id);
        }
        public List<Restaurant> GetRestaurants()
        {
            return _restaurantRepository.Get();
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Create(restaurant);
            _restaurantRepository.SaveChanges();
        }

        public bool RestaurantExists(Expression<Func<Restaurant, bool>> expression)
        {
            return _restaurantRepository.Exists(expression);
        }

        public Restaurant FindRestaurant(int id)
        {
            return _restaurantRepository.FindRestaurant(id);
        }

        public List<Restaurant> GetRestaurants(Expression<Func<RestaurantViewModel, bool>> expression)
        {
            var viewModelParameter = Expression.Parameter(typeof(RestaurantViewModel), "viewModel");

            var restaurantExpression = Expression.Lambda<Func<Restaurant, bool>>(
                Expression.Invoke(expression,
                    Expression.Property(viewModelParameter, nameof(RestaurantViewModel.city)),
                    Expression.Property(viewModelParameter, nameof(RestaurantViewModel.address)),
                    Expression.Property(viewModelParameter, nameof(RestaurantViewModel.Name)),
                    Expression.Property(viewModelParameter, nameof(RestaurantViewModel.phonenumber)),
                    Expression.Property(viewModelParameter, nameof(RestaurantViewModel.OpeningHours))
                ),
                viewModelParameter
            );


            return _restaurantRepository.Restaurants(restaurantExpression);
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            return _restaurantRepository.Update(restaurant);
        }
    }
}
