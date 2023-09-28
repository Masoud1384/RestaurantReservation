using DataAccessLayer.Models;

namespace DataAccessLayer.IRepositories
{
    public interface IUserTokenRepository : IRepository<int,UserToken>
    {
        void SaveTokenInDataBase(UserToken token);
    }
}
