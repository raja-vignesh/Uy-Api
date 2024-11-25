using Core.Restaurants.Domain.Entities;
using MediatR;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery(string id): IRequest<RestaurantResponseDTO?>
    {
        public string Id { get; set; } = id;
    }
}
