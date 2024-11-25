using AutoMapper;
using Core.Restaurants.Domain.Entities;
using Core.Restaurants.Domain.Service;
using Core.Restaurants.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.PatchRestaurant
{
    public class PatchRestaurantCommandHandler(IMapper mapper, IResturantRepository repo,ILogger<PatchRestaurantCommandHandler> logger) : IRequestHandler<PatchRestaurantCommand, RestaurantResponseDTO>
    {
        public async Task<RestaurantResponseDTO> Handle(PatchRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Patching restuarant with {id} and {@request}", request.Id, request);
            Restaurant rest = await repo.GetRestaurant(Guid.Parse(request.Id));
            if (rest == null)
            {
                throw new NotFoundCustomException(nameof(Restaurant), request.Id.ToString());
            }
            rest.Name = request.Name;
            rest.Description = request.Description;
            rest.HasDelivery = request.HasDelivery; 
            var response = await repo.PatchRestuarant(rest);
            RestaurantResponseDTO dto = mapper.Map<RestaurantResponseDTO>(response);
            return dto;
        }
    }
}
