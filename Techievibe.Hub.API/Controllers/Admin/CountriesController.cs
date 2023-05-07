using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using Techievibe.Hub.Logging.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Techievibe.Hub.API.Controllers.Admin
{

    /// <summary>
    /// A controller to manage CRUD operations on countries of the world.
    /// </summary>

    [Route("api/admin/[controller]")]
    [ApiController]
//    [TypeFilter(typeof(ApiAdminRoleAttribute))]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error")]
    public class CountriesController : ControllerBase
    {
        private readonly ISumoLogger _logger;
        private readonly ILogger<CountriesController> _msLogger;
        /// <summary>
        /// Constructor for countries controller
        /// </summary>
        public CountriesController(ISumoLogger logger, ILogger<CountriesController> msLogger)
        {
            _logger = logger;
            _msLogger = msLogger;
        }

        /// <summary>
        /// A collection of countries as a string
        /// </summary>
        public List<string> Countries = new List<string>() { "India", "Australia", "Austria", "South Africa", "England", "West Indies", "Srilanka", "Singapore" };

        /// <summary>
        /// Gets a list of all countries
        /// </summary>
        /// <returns>Returns a list of all countries.</returns>

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Sample1");

            try
            {
                _logger.LogWarn("Argument Exception about to occur.");
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                _logger.LogError("Some Error occurred", ex);
            }

            return Countries;
        }

        ///// <summary>
        ///// Inbound Email Posted
        ///// </summary>

        [HttpPost("inbound")]
        public async Task<IActionResult> PostInbound([FromBody] string requestBody)
        {
            _logger.LogInfo("Sample1 Inbound");

            try
            {
                
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    string rawValue = await reader.ReadToEndAsync();

                    _logger.LogInfo("Header Start\n");
                    foreach (var header in Request.Headers) 
                    {
                        _logger.LogInfo($"Key : {header.Key}, Value : {header.Value}");
                    }

                    _logger.LogInfo("Header End\n");

                    _logger.LogInfo("Body Start\n");
                    _logger.LogInfo($"{rawValue}");
                    _logger.LogInfo("\nBody End");
                }
                if (Request.HasFormContentType && Request.Form.Files.Any())
                {
                    _logger.LogInfo("The request info is  : HasformContentType" + Request.HasFormContentType.ToString() + ", Files available is : " + Request.Form.Files.Any());
                }
                else
                {
                    _logger.LogInfo("The request info is  : HasformContentType" + Request.HasFormContentType.ToString() + ", Files available is : " + Request.Form.Files.Any());
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Some Error occurred", ex);
            }

            return Ok("Success");
        }

        ///// <summary>
        ///// Gets a country by Id.
        ///// </summary>
        ///// <returns>Returns a single country that matches the given Id.</returns>

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return Countries[id];
        //}

        ///// <summary>
        ///// Gets a country by Code.
        ///// </summary>
        ///// <returns>Returns a single country that matches the given country code.</returns>

        //[HttpGet("{countryCode}")]
        //public string Get(string code)
        //{
        //    return Countries[0];
        //}

        ///// <summary>
        ///// Adds a new country.
        ///// </summary>
        ///// <returns>Returns true, if country was added successfully.</returns>

        //[HttpPost]
        //public bool Add([FromBody] string value)
        //{
        //    return true;
        //}

        ///// <summary>
        ///// Updates a country.
        ///// </summary>
        ///// <returns>Returns true, if country was updated successfully.</returns>

        //[HttpPut("{id}")]
        //public bool Put(int id, [FromBody] string value)
        //{
        //    return true;
        //}


        ///// <summary>
        ///// Deletes a country.
        ///// </summary>
        ///// <returns>Returns true, if country was deleted successfully.</returns>

        //[HttpDelete("{id}")]
        //public bool Delete(int id)
        //{
        //    return true;
        //}
    }
}
