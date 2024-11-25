using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.PatchRestaurant
{
    public class PatchRestaurantValidator: AbstractValidator<PatchRestaurantCommand>
    {
        public PatchRestaurantValidator()
        {
            RuleFor( dto => dto.Name).Length(3,100).WithMessage("Name should be between 3 and 100 chars");
        }

    }
}
