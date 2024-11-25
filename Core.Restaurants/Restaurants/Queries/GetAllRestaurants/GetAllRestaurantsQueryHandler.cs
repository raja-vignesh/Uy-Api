using AutoMapper;
using Core.Restaurants.Domain.Service;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(IResturantRepository repo, IMapper mapper, ILogger<GetAllRestaurantsQueryHandler> logger) : IRequestHandler<GetAllRestaurantQuery, List<RestaurantResponseDTO>>
    {
        public async Task<List<RestaurantResponseDTO>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Gettinga all restaurants");

            var rests = await repo.GetAllRestaurants();


            // return rests.Select(x => x.ToRestaurantResponseDTO()).ToList();
            var restsDto = mapper.Map<List<RestaurantResponseDTO>>(rests);


            return restsDto.ToList();
        }
    }
}
