using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestCQRSProject.Interfaces;
using TestCQRSProject.Locations.Models;
using TestCQRSProject.Services;

namespace TestCQRSProject.Locations.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, LocationDTO>
    {
        private readonly IDataAccess _dataAccess;
        private readonly ILocationService _locationService;
        private readonly ILocationProvider _locationProvider;

        public CreateLocationCommandHandler(IDataAccess dataAccess, ILocationService locationService, ILocationProvider locationProvider)
        {
            _dataAccess = dataAccess;
            _locationService = locationService;
            _locationProvider = locationProvider;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The reply to Chatbot after processed with services</returns>
        public async Task<LocationDTO> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            // Get data from data access layer
            var result = await _dataAccess.ExecuteProc("CreateLocationProc");

            // Location provider will create ILocation
            var location = _locationProvider.CreateLocation(result);

            // Call Service to process any business rules if needed
            var res = _locationService.ProcessRules(location);

            // Create DTO
            var locationDTO = new LocationDTO();
            locationDTO.Location = location;
            locationDTO.Result = true;
            
            return locationDTO;
        }
    }
}
