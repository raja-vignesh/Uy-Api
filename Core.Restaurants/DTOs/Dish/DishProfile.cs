using AutoMapper;
using RestaurantsPresentation.Api.DTOs.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DishEntity = Core.Restaurants.Domain.Entities;

namespace Core.Restaurants.DTOs.Dish
{
    public class DishProfile : Profile
    {
        public DishProfile() {
            CreateMap<DishEntity.Dish, DishResponseDTO>();
        }
    }
}
