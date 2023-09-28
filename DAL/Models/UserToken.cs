namespace DataAccessLayer.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string TokenHash { get; set; }
        public DateTime Expired { get; set; }
        public User user { get; set; }
    }
}
