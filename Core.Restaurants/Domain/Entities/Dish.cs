using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Domain.Entities
{
    public class Dish
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public int? KiloCalories { get; set; }

        public Guid RestaurantId { get; set; }
    }
}
