using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TestCQRSProject.Locations.Models;

namespace TestCQRSProject.Locations.Commands
{
    public class CreateLocationCommand : IRequest<LocationDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
