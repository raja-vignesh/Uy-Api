using Core.Restaurants.Domain.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand(string id):IRequest
    {
        public string Id { get; set; } = id;
    }
}
