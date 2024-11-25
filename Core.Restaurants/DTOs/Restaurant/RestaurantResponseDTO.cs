using RestaurantEntity = Core.Restaurants.Domain.Entities;
using RestaurantsPresentation.Api.DTOs.Dish;

namespace RestaurantsPresentation.Api.DTOs.Restaurant
{
    public class RestaurantResponseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string Category { get; set; } = string.Empty;

        public bool HasDelivery { get; set; }


        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public List<DishResponseDTO> Dishes { get; set; } = new List<DishResponseDTO>();

    }

    public static class RestaurantExtension
    {
        public static RestaurantResponseDTO ToRestaurantResponseDTO(this RestaurantEntity.Restaurant rest )
        {
            return new RestaurantResponseDTO() { 
                Id = rest.Id,
                Name = rest.Name,
                Description = rest.Description,
                Category = rest.Category,
                HasDelivery = rest.HasDelivery,
                City = rest.Address.City ?? string.Empty,
                Street = rest.Address.Street ?? string.Empty,
                PostalCode = rest.Address.PostalCode ?? string.Empty,
                Dishes = rest.Dishes.Select(x => x.ToDishReponseDTO()).ToList()
            };
        }
    }
}
