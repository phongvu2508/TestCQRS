using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;
using TestCQRSProject.Locations.Models;

namespace TestCQRSProject.Providers
{
    public class LocationProvider : ILocationProvider
    {
        public ILocation CreateLocation(string name)
        {
            var location = new Location();
            location.Name = name;
            location.Description = "yeah";
            return location;
        }
    }
}
