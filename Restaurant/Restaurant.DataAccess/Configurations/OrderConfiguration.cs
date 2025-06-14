﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.TotalAmount).HasDefaultValue(null).IsRequired(false);
            builder.Property(a=>a.Date).HasDefaultValue(DateTime.Now).IsRequired(false);
        }
    }
}
