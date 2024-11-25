using Core.Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Domain.Service
{
    public interface IResturantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();

        Task<Restaurant?> GetRestaurant(Guid id);

        Task<Guid> CreateRetaurant(Restaurant entity);

        Task<bool> DeleteRetaurant(Restaurant entity);

        Task<Restaurant> PatchRestuarant(Restaurant entity);
    }
}
