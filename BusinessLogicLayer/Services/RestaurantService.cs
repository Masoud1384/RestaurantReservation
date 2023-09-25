using BusinessLogicLayer.Commands.Restaurant;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace BusinessLogicLayer.Services
{
    public class RestaurantService : IRestaurantServices
    {
        private IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public RestaurantViewModel GetRestaurant(int id)
        {
            var r = _restaurantRepository.Get(id);
            var vm = new RestaurantViewModel
            {
                address = r.restaurantInformation.address,
                city = r.restaurantInformation.city,
                Name = r.Name,
                NumberOfTables = r.NumberOfTables,
                OpeningHours = r.OpeningHours,
                phonenumber = r.restaurantInformation.phonenumber
            };
            return vm;
        }
        public List<RestaurantViewModel> GetRestaurants()
        {
            return _restaurantRepository.Get().
                Select(r => new RestaurantViewModel
                {
                    address = r.restaurantInformation.address,
                    city = r.restaurantInformation.city,
                    Name = r.Name,
                    NumberOfTables = r.NumberOfTables,
                    OpeningHours = r.OpeningHours,
                    phonenumber = r.restaurantInformation.phonenumber
                }).ToList();
        }
        public List<RestaurantViewModel> GetRestaurants(Expression<Func<RestaurantViewModel, bool>> expression)
        {
            return _restaurantRepository.Get().
                Select(r => new RestaurantViewModel
                {
                    address = r.restaurantInformation.address,
                    city = r.restaurantInformation.city,
                    Name = r.Name,
                    NumberOfTables = r.NumberOfTables,
                    OpeningHours = r.OpeningHours,
                    phonenumber = r.restaurantInformation.phonenumber
                }).ToList();
        }
        public int CreateRestaurant(CreateRestaurantCommand restaurant)
        {
            var result = new Restaurant(restaurant.Name, restaurant.OpeningHours, restaurant.NumberOfTables,
                new Address(restaurant.address, restaurant.city, restaurant.phonenumber));
            _restaurantRepository.Create(result);
            _restaurantRepository.SaveChanges();
            return result.Id;
        }
        public bool RestaurantExists(Expression<Func<RestaurantViewModel, bool>> expression)
        {
            var exp = Converter(expression);
            return _restaurantRepository.Exists(exp);
        }
        public RestaurantViewModel FindRestaurant(int id)
        {
            var r = _restaurantRepository.FindRestaurant(id);
            var vm = new RestaurantViewModel
            {
                address = r.restaurantInformation.address,
                city = r.restaurantInformation.city,
                Name = r.Name,
                NumberOfTables = r.NumberOfTables,
                OpeningHours = r.OpeningHours,
                phonenumber = r.restaurantInformation.phonenumber
            };
            return vm;
        }
        public bool UpdateRestaurant(UpdateRestaurantCommand restaurant)
        {
            var result = new Restaurant(restaurant.Name, restaurant.OpeningHours, restaurant.NumberOfTables
                , new Address(restaurant.address, restaurant.city, restaurant.phonenumber));
            return _restaurantRepository.Update(result);
        }
        private Expression<Func<Restaurant, bool>> Converter(Expression<Func<RestaurantViewModel, bool>> expression)
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
            return restaurantExpression;
        }
        public bool DeleteRestaurant(int id)
        {
            if (id > 0)
            {
                return _restaurantRepository.Delete(id);
            }
            return false;
        }
    }
}
