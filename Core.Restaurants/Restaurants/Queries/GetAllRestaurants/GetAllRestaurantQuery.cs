using MediatR;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantQuery :IRequest<List<RestaurantResponseDTO>>
    {

    }
}
