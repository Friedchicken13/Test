using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Test.Constants;
using Test.Models.DTOs;

namespace Test.Repository
{
    public class ConfRepository : IConfRepository
    {
        List<SessionDTO> getsessionListResponse = new List<SessionDTO>();
             
        private ILogger _logger;

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string authToken;

        public ConfRepository(IHttpContextAccessor contextAccessor, ILogger<ConfRepository> logger)
        {
            _contextAccessor = contextAccessor;
            authToken = Constants.API.Token;
            _logger = logger;
        }

        public async Task<SessionDTO> GetSession(int id)
        {
            SessionDTO getSessionResponse;
            var endpoint = GetEndpoint(API.GetSession)+ id;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization",  authToken);
                    HttpResponseMessage response = await client.GetAsync(new Uri(endpoint));
                    var bodyContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                    getSessionResponse = JsonConvert.DeserializeObject<SessionDTO>(bodyContent);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SessionDTO exception occured." + ex.Message, ex);
                throw;
            }
            return getSessionResponse;
        }

        public async Task<List<SessionDTO>> GetSessions()
        {
            List<SessionDTO> getSessionsResponse = null;
            var endpoint = GetEndpoint(API.GetSessions);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "67f50e1f75e84a78856eb15d8ec10a48");
                    client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    client.DefaultRequestHeaders.Add("Api-version", "v1");
                    HttpResponseMessage response = await client.GetAsync(new Uri(endpoint));
                    var bodyContent = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                    var getSessionsResponse1 = JsonConvert.DeserializeObject<GetSessionsResponse>(bodyContent);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SessionDTO exception occured." + ex.Message, ex);
                throw;
            }
            return getSessionsResponse;
        }

        //public async Task<string> GetSessionTcs(int id)
        //{
        //    throw new NotImplementedException();
        //}

        private string GetEndpoint(string api)
        {
            return Constants.API.Connection + api + "/";
        }
    }
}
