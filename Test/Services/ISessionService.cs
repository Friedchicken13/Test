using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Controllers;
using Test.Models;

namespace Test.Services
{
    public interface ISessionService
    {
        Task<List<Session>> GetSessionsListAndTcs(string sName, int dayNo, int timeslot);
    }
}
