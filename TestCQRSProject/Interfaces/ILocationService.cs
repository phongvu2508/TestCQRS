using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;

namespace TestCQRSProject.Interfaces
{
    public interface ILocationService
    {
        bool ProcessRules(ILocation location);

    }
}
