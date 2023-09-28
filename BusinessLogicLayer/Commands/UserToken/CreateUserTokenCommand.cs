namespace BusinessLogicLayer.Commands.UserToken
{
    public class CreateUserTokenCommand
    {
        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int userId { get; set; }
    }
}
