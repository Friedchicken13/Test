using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.DTOs;

namespace Test.Repository
{
    public interface IConfRepository
    {
        Task<SessionDTO> GetSession(int id);
        Task<List<SessionDTO>> GetSessions();
        //Task<string> GetSessionTcs(int id);

    }
}
