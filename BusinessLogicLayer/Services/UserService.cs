using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User FindUser(Expression<Func<User, bool>> expression)
        {
            return _userRepository.FindUser(expression);
        }

        public List<User> GetUsers(Expression<Func<User, bool>> expression)
        {
            return _userRepository.Ingredients(expression);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
