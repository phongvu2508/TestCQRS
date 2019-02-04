using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCQRSProject.Interfaces
{
    public interface IDataAccess
    {
        Task<string> ExecuteProc(string procName);
    }
}
