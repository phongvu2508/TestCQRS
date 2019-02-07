using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestCQRSProject.Interfaces;
using TestCQRSProject.Locations.Models;
using TestCQRSProject.Services;

namespace TestCQRSProject.Locations.Queries
{
    public class GetLocationQueryHandlercs : IRequestHandler<GetLocationQuery, LocationDTO>
    {
        private readonly IDataAccess _dataAccess;
        private readonly ILocationService _locationService;
        private readonly ILocationProvider _locationProvider;

        public GetLocationQueryHandlercs(IDataAccess dataAccess, ILocationService locationService, ILocationProvider locationProvider)
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
        public async Task<LocationDTO> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            // Get data from data access layer
            var result = await _dataAccess.ExecuteProc("LocationQueryProc");

            // Location provider will create ILocation
            // TODO: This will be inject into DataAccess
            var location = _locationProvider.CreateLocation(result);

            // Call Service to process any business rules if needed
            // TODO: Use MediatR to trigger service to process the needed rule, don't need to request directly.
            var res = _locationService.ProcessRules(location);

            // Create DTO
            // TODO: potential move this to another DTO Provider if the creation is complex enough
            var locationDTO = new LocationDTO();
            locationDTO.Location = location;
            locationDTO.Result = true;
            
            return locationDTO;
        }
    }
}
