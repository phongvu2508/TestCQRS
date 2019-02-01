using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;

namespace TestCQRSProject.Locations.Models
{
    public class LocationDTO
    {
        public bool Result { get; set; }
        public ILocation Location { get; set; }
    }
}
