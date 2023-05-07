using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics;
using Techievibe.Hub.API.Models;
using Techievibe.Hub.API.ResponseExamples;
using Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.Services.Common.Interfaces;

namespace Techievibe.Hub.API.Controllers.Users
{
    /// <summary>
    /// A controller to manage user account CRUD.
    /// </summary>
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
        public IActionResult Create([FromBody] UserCreateRequest userCreateRequest)
        {
            var watch = new Stopwatch();
            watch.Start();
            string createdId = Guid.NewGuid().ToString();
            watch.Stop();
            return Created($"{Request.Path}", new ApiResponse<string>(createdId, 201, null, watch.ElapsedMilliseconds.ToString()));
        }


        /// <summary>
        /// Gets all users in the system.
        /// </summary>
        /// <returns></returns>

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
            var users = await userManager.GetAllUsers();
            watch.Stop();
            return Ok(new ApiResponse<List<User>>(users, 200, null, watch.ElapsedMilliseconds.ToString()));
        }


        /// <summary>
        /// Gets a user by id.
        /// </summary>
        /// <returns></returns>

        [HttpGet("{userId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CreateNewUserExample))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(BadRequestExample))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(ForbiddenRequestExample))]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var watch = new Stopwatch();
            watch.Start();
            var user = await userManager.GetUserById(userId);
            watch.Stop();
            return Ok(new ApiResponse<User>(user, 200, null, watch.ElapsedMilliseconds.ToString()));
        }


        /// <summary>
        /// Updates a user
        /// </summary>
        /// <returns></returns>

        [HttpPut("{userId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CreateNewUserExample))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(BadRequestExample))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(ForbiddenRequestExample))]
        public async Task<IActionResult> UpdateUser(int userId, UserCreateRequest userCreateRequest)
        {
            var watch = new Stopwatch();
            watch.Start();
            var user = await userManager.GetUserById(userId);
            watch.Stop();
            return Ok(new ApiResponse<User>(user, 200, null, watch.ElapsedMilliseconds.ToString()));
        }


        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns></returns>

        [HttpDelete("{userId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CreateNewUserExample))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(BadRequestExample))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ApiResponse<string>))]
        [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(ForbiddenRequestExample))]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var watch = new Stopwatch();
            watch.Start();
            var user = await userManager.GetUserById(userId);
            watch.Stop();
            return Ok(new ApiResponse<bool>(true, 200, null, watch.ElapsedMilliseconds.ToString()));
        }
    }
}
