﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Configurations;

namespace Restaurant.DataAccess.Data
{
    public class RestaurantContext:DbContext
    {
        public DbSet<MenuItem> menuItems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = Restaurant; User Id = sa; Password = Senan123@; TrustServerCertificate = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MenuItemConfiguration).Assembly);
        }
    }
}
