using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccessLayer.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string TokenHash { get; set; }
        public DateTime Expired { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public UserToken()
        {

        }
        public UserToken(string TokenHash, DateTime expiredTime, int userId)
        {
            this.TokenHash = TokenHash;
            this.Expired = expiredTime;
            this.userId = userId;
        }
    }
}
