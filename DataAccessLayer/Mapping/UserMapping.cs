using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation;

namespace DataAccessLayer.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn(1000, 1);
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.HasMany(u => u.Reservations)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
