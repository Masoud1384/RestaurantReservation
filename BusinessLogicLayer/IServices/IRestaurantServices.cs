using BusinessLogicLayer.Commands.Restaurant;
using System.Linq.Expressions;

namespace BusinessLogicLayer.IServices
{
    public interface IRestaurantServices
    {
        List<RestaurantViewModel> GetRestaurants();
        bool RestaurantExists(Expression<Func<RestaurantViewModel, bool>> expression);
        RestaurantViewModel FindRestaurant(int id);
        void CreateRestaurant(CreateRestaurantCommand restaurant);
        List<RestaurantViewModel> GetRestaurants(Expression<Func<RestaurantViewModel, bool>> expression);
        bool UpdateRestaurant(UpdateRestaurantCommand restaurant);
        bool DeleteRestaurant(int id);
    }
}
