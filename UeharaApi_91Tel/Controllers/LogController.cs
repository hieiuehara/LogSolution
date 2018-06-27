using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UeharaApi_91Tel.Repositories;
using UeharaApi_91Tel.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UeharaApi_91Tel.Models;

namespace UeharaApi_91Tel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController: ControllerBase
    {
        private readonly IClientApi91 _clientApi;
        private readonly ILogResponseRepository _logRepository;
        private readonly ILogger<LogController> _logger;

        public LogController(IClientApi91 clientApi,ILogResponseRepository logRepository, ILogger<LogController> logger)
        {
            _clientApi = clientApi;
            _logRepository = logRepository;
            _logger = logger;
        }

        // GET api/log/5
        [HttpGet]
        public ActionResult<List<LogResponse>> Get([FromQuery(Name = "pagesize")]int pagesize)
        {
            try{
                var result = _logRepository.GetAllWithPagination(pagesize).Result;
                return Ok(result);
            }
            catch(Exception e)
            {
                _logger.LogError("[ERROR - Log Get]", e.Message);
                return BadRequest(e.Message);
            }
        }

        // POST api/log
        [HttpPost]
        public void Post([FromBody] string date)
        {
            var auth = _clientApi.Authentication("password", "teste", "teste").Result;
            if (!string.IsNullOrEmpty(auth.Access_Token))
            {
                var logs = _clientApi.GetLogs(auth.Access_Token, date).Result;
                if (logs.Count > 0)
                {
                    foreach (var log in logs)
                    {
                        try
                        {
                            _logRepository.Insert(log);
                        }
                        catch (Exception e)
                        {
                            _logger.LogError("[ERROR - Log Insert]", e.Message);
                            continue;
                        }
                    }
                }
            }
        }
    }
}
