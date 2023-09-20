using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.ReservationTime).
                HasDefaultValue(DateTime.Now);
            builder.Property(r => r.reservationStatus)
                .HasConversion(r=>r.ToString() , r=>(ReservationStatus)Enum.Parse(typeof(ReservationStatus),r));
            builder.Property(r => r.NumberOfGuests)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(r => r.ReservationTime)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
