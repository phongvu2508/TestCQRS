using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCQRSProject.Interfaces
{
    public interface ILocation
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
