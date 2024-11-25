using Core.Restaurants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Restaurants
{
    public class RestaurantDBContext:DbContext
    {
        public RestaurantDBContext(DbContextOptions options):base(options) { 
        
        }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Dish> dishes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                   .HasMany(r => r.Dishes)
                   .WithOne()
                   .HasForeignKey(r => r.RestaurantId);
                    
        }
        
    }
}
