using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class UserTokenRepository : Repository<int, UserToken>, IUserTokenRepository
    {
        private readonly Context _context;
        public UserTokenRepository(Context context)
            :base(context)
        {
            _context = context;
        }

        public void SaveTokenInDataBase(UserToken token)
        {
            _context.UserTokens.Add(token);
            _context.SaveChanges();
        }
    }
}
