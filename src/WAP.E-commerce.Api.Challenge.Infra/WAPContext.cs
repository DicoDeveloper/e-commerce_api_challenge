using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WAP.E_commerce.Api.Challenge.Domain.Addresses.Entities;
using WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;

namespace WAP.E_commerce.Api.Challenge.Infra
{
    public class WAPContext : DbContext
    {
        public WAPContext(DbContextOptions<WAPContext> options)
            : base(options)
        {
        }

        public DbSet<Order> FoodCourts { get; set; }
        public DbSet<OrderItem> RestaurantGroups { get; set; }
        public DbSet<Address> Restaurants { get; set; }
        public DbSet<DeliveryTeam> ProductGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}