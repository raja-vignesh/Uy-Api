using DishEnity = Core.Restaurants.Domain.Entities;

namespace RestaurantsPresentation.Api.DTOs.Dish
{
    public class DishResponseDTO
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public int? KiloCalories { get; set; }
    }

    public static class DishExtension {
        public static DishResponseDTO ToDishReponseDTO(this DishEnity.Dish dto) { 
            return new DishResponseDTO { ID = dto.ID,Name = dto.Name,Description = dto.Description, Price = dto.Price, KiloCalories = dto.KiloCalories};
        }
    }

}
