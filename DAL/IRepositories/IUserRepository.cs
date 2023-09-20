using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository : IRepository<int, User>
    {
        User FindUser(Expression<Func<User, bool>> expression);
        List<User> Ingredients(Expression<Func<User, bool>> expression);
        bool Update(User user);
    }
}
