using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics;
using Techievibe.Hub.API.Models;
using Techievibe.Hub.API.ResponseExamples;
using Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.Services.Common.Interfaces;

namespace Techievibe.Hub.API.Controllers
{
    [Route("api/user-accounts")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UserAccountsController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="userCreateRequest">User Create Payload</param>
        /// <returns></returns>

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(CreateNewUserExample))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(BadRequestExample))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(ForbiddenRequestExample))]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest userCreateRequest)
        {
            var watch = new Stopwatch();
            watch.Start();
            string createdId = Guid.NewGuid().ToString();
            watch.Stop();
            return Created($"{Request.Path}", new ApiResponse<string>(createdId, 201, null, watch.ElapsedMilliseconds.ToString()));
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CreateNewUserExample))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(BadRequestExample))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(ForbiddenRequestExample))]
        public async Task<IActionResult> GetAll()
        {
            var watch = new Stopwatch();
            watch.Start();
            var users = userManager.GetAllUsers().Result;
            watch.Stop();
            return Ok(new ApiResponse<List<User>>(users, 200, null, watch.ElapsedMilliseconds.ToString()));
        }
    }
}
