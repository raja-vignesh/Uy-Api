using Core.Restaurants.DTOs.Restaurant;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Restaurants.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantValidator : AbstractValidator<CreateRestuarantCommand>
    {

        private List<string> categories = ["Indian", "Chinese", "Thai", "Lebanese", "western"];
        public CreateRestaurantValidator()
        {
            RuleFor(dto => dto.Name).Length(3, 100).WithMessage("Name should be 3 and 100 chars long");

            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Email is not valid");

            RuleFor(dto => dto.ContactNumber).Matches("^[0-9]{10}$").WithMessage("Number is not valid");

            RuleFor(dto => dto.Category).Must(category => categories.Contains(category))
                        .WithMessage("Category is not valid");

        }
    }
}
