using Core.Restaurants.Domain.Entities;
using Core.Restaurants.Domain.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Restaurants.Repositories
{
    public class RestaurantRepository(RestaurantDBContext dBContext) : IResturantRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await dBContext.
                                        restaurants.Include(r => r.Address).Include(r => r.Dishes).ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetRestaurant(Guid id)
        {
            Restaurant? rest = await dBContext.restaurants.Include(r => r.Address).Include(r => r.Dishes).Where( x => x.Id == id ).FirstOrDefaultAsync();
            return rest;
        }

        public async Task<Guid> CreateRetaurant(Restaurant entity)
        {
            var resp = await dBContext.restaurants.AddAsync(entity);
            await dBContext.SaveChangesAsync();
            return entity.Id;

        }

       
        public async Task<bool> DeleteRetaurant(Restaurant entity)
        {
            dBContext.restaurants.Remove(entity);
            await dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<Restaurant> PatchRestuarant(Restaurant entity)
        {
            dBContext.restaurants.Update(entity);
            await dBContext.SaveChangesAsync();
            return entity;
        }
    }
}
