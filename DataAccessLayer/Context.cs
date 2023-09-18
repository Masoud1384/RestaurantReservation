using Microsoft.EntityFrameworkCore;
using RestaurantReservation;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Reservation> reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var assembly = typeof(Mapping.UserMapping).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
