using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.DTOs.Restaurant
{
    public class CreateRestaurantDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public bool HasDelivery { get; set; }

        public string? ContactEmail { get; set; } = string.Empty;

        public string? ContactNumber { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;
    }
}
