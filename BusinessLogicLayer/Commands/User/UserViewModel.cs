    namespace BusinessLogicLayer.Commands.User
{
    public class UserViewModel : CreateUserCommand
    {
        public int id { get; set; }

        public List<ApiLink> links { get; set; }
    }
}
