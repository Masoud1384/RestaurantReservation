using RestaurantReservation;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class RestaurantRepository : Repository<int, Restaurant>, IRestaurantRepository
    {
        private readonly Context _context;

        public RestaurantRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public Restaurant FindRestaurant(Expression<Func<Restaurant, bool>> expression)
        {
            var result = _context.restaurants.FirstOrDefault(expression);
            return result;
        }

        public List<Restaurant> Ingredients(Expression<Func<Restaurant, bool>> expression)
        {
            var result = _context.restaurants.Where(expression).ToList();
            return result;
        }

        public bool Update(Restaurant restaurant)
        {
            _context.Update(restaurant);
            var result = _context.SaveChanges();
            return result == 1;
        }
    }
}
