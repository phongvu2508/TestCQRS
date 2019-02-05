using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCQRSProject.Locations.Commands;
using TestCQRSProject.Locations.Models;
using TestCQRSProject.Locations.Notifications;
using TestCQRSProject.Locations.Queries;

namespace TestCQRSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/location/5
        [HttpGet("{id}")]
        public async Task<LocationDTO> GetLocation(int id)
        {
            var query = new GetLocationQuery();
            query.Id = id;

            return await _mediator.Send<LocationDTO>(query);
        }

        // POST api/location?name=haha&description=hihi
        [HttpPost]
        public async Task CreateLocation(string name, string description)
        {
            var command = new CreateLocationCommand();
            command.Name = name;
            command.Description = description;
            
            var result = await _mediator.Send<LocationDTO>(command);

            if (result.Result)
            {
                var notification = new LocationCreatedModel();
                notification.Id = result.Location.Id;

                await _mediator.Publish<LocationCreatedModel>(notification);
            }
        }
    }
}