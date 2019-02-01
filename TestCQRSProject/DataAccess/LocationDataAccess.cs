using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;

namespace TestCQRSProject.DataAccess
{
    public class LocationDataAccess : IDataAccess
    {
        public string ExecuteProc(string procName)
        {
            return "something";
        }
    }
}
