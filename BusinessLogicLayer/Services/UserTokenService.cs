using BusinessLogicLayer.Commands.UserToken;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IUserTokenRepository _userTokenRepository;

        public UserTokenService(IUserTokenRepository userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }
        public void SaveToken(CreateUserTokenCommand createUserTokenCommand)
        {
            var tokenHash = GetTokenHash(createUserTokenCommand.Token);
            var tokenUser = new UserToken(tokenHash, createUserTokenCommand.ExpiredDate, createUserTokenCommand.userId);
            _userTokenRepository.SaveTokenInDataBase(tokenUser);
        }
        private string GetTokenHash(string token)
        {
            var algorithm = new SHA256CryptoServiceProvider();
            var byValue = Encoding.UTF8.GetBytes(token);
            var byHash = algorithm.ComputeHash(byValue);
            return Convert.ToBase64String(byHash);
        }
    }
}
