using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository : IRepository<int, User>
    {
        User FindUser(int id);
        List<User> Users(Expression<Func<User, bool>> expression);
        bool Update(User user);
    }
}
