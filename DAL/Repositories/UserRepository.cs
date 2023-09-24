using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

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
        public User FindUser(int id)
        {
            var result = _context.users.FirstOrDefault(r => r.Id== id);
            return result;
        }

        public List<User> Users(Expression<Func<User, bool>> expression)
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

        public int CreateUser(User theUser)
        {
            var user = _context.users.Add(theUser);
            _context.SaveChanges();
            return theUser.Id;
        }

        public bool Delete(int id)
        {
           var user = _context.users.Find(id);
            _context.users.Remove(user);
            return _context.SaveChanges() == 1;
        }
    }
}
