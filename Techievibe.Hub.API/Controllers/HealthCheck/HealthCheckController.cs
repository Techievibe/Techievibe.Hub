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
    [Route("api/health-check")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ICommonManager commonManager;
        /// <summary>
        /// A constructor for Health check
        /// </summary>
        public HealthCheckController(ICommonManager commonManager)
        {
            this.commonManager = commonManager;
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
            watch.Stop();
            return Ok(new ApiResponse<string>("Ready", 200, new List<string>(), watch.ElapsedMilliseconds.ToString()));
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

            watch.Stop();

            return Ok(new ApiResponse<bool>(result, 200, new List<string>(), watch.ElapsedMilliseconds.ToString()));
        }
    }
}
