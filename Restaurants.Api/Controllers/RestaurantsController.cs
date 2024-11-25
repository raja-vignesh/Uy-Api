using Core.Restaurants.Domain.Entities;
using Core.Restaurants.Domain.Service;
using Core.Restaurants.DTOs.Restaurant;
using Core.Restaurants.Restaurants;
using Core.Restaurants.Restaurants.Commands.CreateRestaurant;
using Core.Restaurants.Restaurants.Commands.DeleteRestaurant;
using Core.Restaurants.Restaurants.Commands.PatchRestaurant;
using Core.Restaurants.Restaurants.Queries.GetAllRestaurants;
using Core.Restaurants.Restaurants.Queries.GetRestaurantById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsPresentation.Api.DTOs.Restaurant;

namespace RestaurantsPresentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<RestaurantResponseDTO>>> Get()
        {
            List<RestaurantResponseDTO> res = await mediator.Send(new GetAllRestaurantQuery());
            return Ok(res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<ActionResult<RestaurantResponseDTO>>GetById(string id)
        {
            Guid gu = Guid.Parse(id);
            RestaurantResponseDTO? rt = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (rt != null)
            {
                return Ok(rt);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 201)]

        public async Task<ActionResult> CreateRestaurant(CreateRestuarantCommand command)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                string msg = string.Join("\n", errorMessages);
                return BadRequest(msg);
            }
            string id = await mediator.Send(command);
            if (id != null)
            {
                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 204)]
        public async Task<IActionResult> DeleteRestaurantById(string id)
        {
            if (id == null)
            {
                return BadRequest("Invalid Id");
            }

            await mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
          

        }

        [HttpPatch("{id}")]
        [ProducesResponseType(statusCode: 400)]
        public async Task<ActionResult<RestaurantResponseDTO>> PatchRestuarant([FromRoute] string id,PatchRestaurantCommand command)
        {
            command.Id = id;

            //if (!ModelState.IsValid)
            //{
            //    List<string> errorMsgs = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            //    string errorM = string.Join("\n", errorMsgs);
            //    return BadRequest(errorM);
            //}

            var rst = await mediator.Send(new GetRestaurantByIdQuery(id));

            if (rst != null)
            {
                RestaurantResponseDTO dto = await mediator.Send(command);
                return Ok(dto);
            }

            return BadRequest("bad request");

        }
    }
}
