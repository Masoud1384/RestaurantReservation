using BusinessLogicLayer.Commands.UserToken;

namespace BusinessLogicLayer.IServices
{
    public interface IUserTokenService
    {
        void SaveToken(CreateUserTokenCommand createUserTokenCommand);
    }
}
