using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Techievibe.Hub.API.Models;
using Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.Logging.Core;
using Techievibe.Hub.Services.Common.Interfaces;

namespace Techievibe.Hub.API.Controllers.Admin
{
    /// <summary>
    /// An admin controller to do CRUD operations on users.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ISumoLogger _logger;
        /// <summary>
        /// An admin controller to do CRUD operations on users.
        /// </summary>
        public UsersController(IUserManager userManager, ISumoLogger logger)
        {
            _userManager = userManager;
            _logger = logger;
        }


        /// <summary>
        /// This endpoint gets all users.
        /// </summary>
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult GetAllUsersAsync()
        {
            var userData = _userManager.GetAllUsers().Result;

            var response = new ApiResponse<List<User>>(userData, 200, new List<string>());

            return Ok(response);
        }

        /// <summary>
        /// This endpoint gets a user by Id.
        /// </summary>
        /// 
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _userManager.GetUserById(id).Result;
            return user;
        }

        /// <summary>
        /// This endpoint is for adding a new user.
        /// </summary>
        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserCreateRequest value)
        {
        }

        /// <summary>
        /// This endpoint is for updating an existing user.
        /// </summary>
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// This endpoint is for deleting a user.
        /// </summary>
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
