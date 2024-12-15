using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DataAccess.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100);
            builder.HasIndex(x=>x.Name).IsUnique();     
        }
    }
}
