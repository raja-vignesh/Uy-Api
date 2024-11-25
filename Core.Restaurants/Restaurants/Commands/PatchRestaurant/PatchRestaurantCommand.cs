using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.PatchRestaurant
{
    public class PatchRestaurantCommand : IRequest<RestaurantResponseDTO>
    {
        [ValidateNever]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool HasDelivery { get; set; }

    }
}
