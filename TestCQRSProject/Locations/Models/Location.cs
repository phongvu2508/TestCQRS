using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;

namespace TestCQRSProject.Locations.Models
{
    public class Location : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
