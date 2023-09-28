namespace DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public ICollection<UserToken> tokens { get; set; }
        public User()
        {
                
        }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User(string name, string email, List<Reservation>? reservations) : this(name, email)
        {
            Reservations = reservations;
        }
    }
}
