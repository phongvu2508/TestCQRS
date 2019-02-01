using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCQRSProject.Interfaces
{
    public interface ILocationProvider
    {
        ILocation CreateLocation(string name);
    }
}
