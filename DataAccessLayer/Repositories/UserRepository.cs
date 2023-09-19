using RestaurantReservation;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository, Repository<int, User>
    {
        public User FindUser(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<User> Ingredients(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(User recipeRating)
        {
            throw new NotImplementedException();
        }
    }
}
