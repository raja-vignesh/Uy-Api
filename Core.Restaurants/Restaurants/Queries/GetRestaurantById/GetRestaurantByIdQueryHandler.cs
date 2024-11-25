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

namespace Core.Restaurants.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(IResturantRepository repo,IMapper mapper,ILogger<GetRestaurantByIdQueryHandler> logger) : IRequestHandler<GetRestaurantByIdQuery, RestaurantResponseDTO>
    {
        public async Task<RestaurantResponseDTO> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting restaurant by {id}",request.Id);

            string id = request.Id;

            Restaurant? rest = await repo.GetRestaurant(Guid.Parse(id));
            if (rest == null)
            {
                throw new NotFoundCustomException(nameof(Restaurant), request.Id.ToString());
            }
            return mapper.Map<RestaurantResponseDTO>(rest);
        }
    }
}
