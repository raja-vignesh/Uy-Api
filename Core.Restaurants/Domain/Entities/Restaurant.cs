using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Domain.Entities
{
    public class Restaurant
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string Category {  get; set; } = string.Empty;

        public bool HasDelivery { get; set; }

        public string ContactEmail { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        public Address? Address { get; set; }

        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
