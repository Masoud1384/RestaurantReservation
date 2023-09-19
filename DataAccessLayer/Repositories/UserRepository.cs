using RestaurantReservation;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : Repository<int, User>, IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
            : base(context)
        {
            _context = context;
        }
        public User FindUser(Expression<Func<User, bool>> expression)
        {
            var result = _context.users.FirstOrDefault(expression);
            return result;
        }

        public List<User> Ingredients(Expression<Func<User, bool>> expression)
        {
            var result = _context.users.Where(expression).ToList();
            return result;
        }

        public bool Update(User user)
        {
            _context.users.Update(user);
            var result = _context.SaveChanges();
            return result == 1;
        }
    }
}
