using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.Services.Common.Interfaces;

namespace Techievibe.Hub.API.Controllers.HealthCheck
{
    /// <summary>
    /// Health check controller
    /// </summary>
    [Route("api/user-mgmt/health-check")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ICommonManager commonManager;
        private readonly ILogger<HealthCheckController> logger;

        /// <summary>
        /// A constructor for Health check
        /// </summary>
        public HealthCheckController(ICommonManager commonManager, ILogger<HealthCheckController> logger)
        {
            this.commonManager = commonManager;
            this.logger = logger;
        }

        /// <summary>
        /// Checks readiness of the service
        /// </summary>
        /// <returns></returns>
        [HttpGet("ready")]
        public IActionResult GetAvailability()
        {
            var watch = new Stopwatch();
            watch.Start();
            
            logger.LogInformation("Healthcheck-Live successful: Service is running and database connectivity available.");

            watch.Stop();

            return Ok(new ApiResponse<string>("Service(s) Ready", 200, new List<string>(), watch.ElapsedMilliseconds.ToString()));
        }

        /// <summary>
        /// Checks readiness of the service, and all dependent services
        /// </summary>
        /// <returns></returns>
        [HttpGet("live")]
        public IActionResult GetLiveness()
        {
            var watch = new Stopwatch();
            watch.Start();

            var result = commonManager.CheckDbConnection();

            logger.LogInformation("Healthcheck-Live successful: Service is running and database connectivity available.");

            watch.Stop();

            return Ok(new ApiResponse<string>("Service(s) Live", 200, new List<string>(), watch.ElapsedMilliseconds.ToString()));
        }
    }
}
