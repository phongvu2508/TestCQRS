using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCQRSProject.Interfaces;

namespace TestCQRSProject.DataAccess
{
    public class LocationDataAccess : IDataAccess
    {
        public async Task<string> ExecuteProc(string procName)
        {
            await Task.Delay(1);

            return "something";
        }
    }
}
