using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository : IRepository<int, User>
    {
        int CreateUser(User user);
        User FindUser(int id);
        List<User> Users(Expression<Func<User, bool>> expression);
        bool Update(User user);
        bool Delete(int id);
    }
}
