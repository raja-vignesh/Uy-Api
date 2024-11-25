using AutoMapper;
using Core.Restaurants.Domain.Entities;
using Core.Restaurants.Domain.Service;
using Core.Restaurants.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using RestaurantsPresentation.Api.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestuarantHandle(IResturantRepository repo, ILogger<DeleteRestuarantHandle> logger) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restuarant with {id}", request.Id);

            var rest = await repo.GetRestaurant(Guid.Parse(request.Id));
            if (rest == null)
            {
                throw new NotFoundCustomException(nameof(Restaurant), request.Id.ToString());
            }
            await repo.DeleteRetaurant(rest);

        }
    }
}
