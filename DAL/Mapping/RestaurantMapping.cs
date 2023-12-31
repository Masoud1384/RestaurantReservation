﻿using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class RestaurantMapping : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(r => r.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(r => r.Name)
                .IsUnique();
            builder
                .OwnsOne(t => t.restaurantInformation);
            builder.Property(r => r.OpeningHours)
                .HasColumnName("openingHours")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(r => r.NumberOfTables)
                .HasColumnName("tableCount")
                .IsRequired();
        }
    }
}
