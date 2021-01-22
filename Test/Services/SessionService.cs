using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Controllers;
using Test.Models;
using Test.Models.DTOs;
using Test.Repository;

namespace Test.Services
{
    public class SessionService : ISessionService
    {
        private readonly IConfRepository _confRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public SessionService(IConfRepository confRepository, ILogger<SessionService> logger, IMapper mapper)
        {
            _confRepository = confRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<Session>> GetSessionsListAndTcs(string sName, int dayNo, int timeslot)
        {
            List<Session> model = new List<Session>();

            try
            {
                List<SessionDTO> response = await _confRepository.GetSessions();
                model = _mapper.Map<List<Session>>(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetSessionsListAndTcs exception occured." + ex.Message, ex);
                throw;
            }
            return model;
        }


    }
}
