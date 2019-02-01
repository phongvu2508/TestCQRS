using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;

namespace TestCQRSProject.Services
{
    public class LocationService : ILocationService
    {
        public bool ProcessRules(ILocation location)
        {
            return true;
        }
    }
}
