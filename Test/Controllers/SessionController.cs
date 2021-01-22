using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {   
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionService _sessionService;
        public SessionController(ILogger<SessionController> logger, ISessionService sessionService )
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessionsListAndTcs(string sName, int dayNo, int timeslot)
        {
            _logger.LogInformation("GetSessionsListAndTcs was invoked");
            IEnumerable<Session> sessions;
            try
            {
                sessions = await _sessionService.GetSessionsListAndTcs(sName,dayNo, timeslot);                
                if (sessions == null)
                {
                    return NotFound("No sessions found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetSessionsListAndTcs exception: {ex}");
                return BadRequest(HttpStatusCode.InternalServerError);
            }

            return Ok(sessions);
        }

       
    }
}
