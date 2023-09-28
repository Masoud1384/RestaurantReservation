using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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

        public DbSet<UserToken> UserTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var assembly = typeof(Mapping.UserMapping).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
