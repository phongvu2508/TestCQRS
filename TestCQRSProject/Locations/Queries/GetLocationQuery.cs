using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TestCQRSProject.Locations.Models;

namespace TestCQRSProject.Locations.Queries
{
    public class GetLocationQuery : IRequest<LocationDTO>
    {
        public int Id { get; set; }
    }
}
