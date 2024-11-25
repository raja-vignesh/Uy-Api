using AutoMapper;
using Core.Restaurants.Domain.Entities;
using Core.Restaurants.Domain.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(IMapper mapper, IResturantRepository repo, ILogger<CreateRestaurantCommandHandler> logger) : IRequestHandler<CreateRestuarantCommand, string>
    {
        public async Task<string> Handle(CreateRestuarantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating restuarant with {@request}", request);
            var restaurant = mapper.Map<Restaurant>(request);
            Guid guid = await repo.CreateRetaurant(restaurant);

            return guid.ToString();
        }
    }
}
