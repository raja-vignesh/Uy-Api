using AutoMapper;
using Core.Restaurants.Domain.Entities;
using Core.Restaurants.Restaurants.Commands.CreateRestaurant;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantEntity = Core.Restaurants.Domain.Entities;

namespace Core.Restaurants.DTOs.Restaurant
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile() {
            CreateMap<RestaurantEntity.Restaurant, RestaurantResponseDTO>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
                .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes ));

            CreateMap<CreateRestuarantCommand, RestaurantEntity.Restaurant>()
                .ForMember(d => d.Address, opt => opt.MapFrom( src => new Address()
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }));

            CreateMap<RestaurantResponseDTO, RestaurantEntity.Restaurant>();

        }
    }
}
