using BusinessLogicLayer.Commands.User;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.IServices
{
    public interface IUserService
    {
        User GetUser(int id);
        List<UserViewModel> GetUsers();
        int CreateUser(CreateUserCommand user);
        bool UserExists(Expression<Func<UserViewModel, bool>> expression);
        UserViewModel FindUser(int id);
        List<User> GetUsers(Expression<Func<UserViewModel, bool>> expression);
        bool UpdateUser(UpdateUserCommand usercmd);
        bool DeleteUser(int id);
    }
}
