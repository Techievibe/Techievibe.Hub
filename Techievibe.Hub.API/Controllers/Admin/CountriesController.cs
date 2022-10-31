using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
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
            //_logger.LogInformation(_logHelper.GetFormattedInformationMessage("Health End Point data logged."));
            //_logger.LogDebug(_logHelper.GetFormattedDebugMessage("Health End Point data logged."));
            //_logger.LogError(_logHelper.GetFormattedErrorMessage("Health End Point data logged."));
            //_logger.LogWarning(_logHelper.GetFormattedWarningMessage("Health End Point data logged."));

            _logger.LogInfo("Sample1", false);
            _logger.LogInfo("Sample2", true);

            try
            {
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                _logger.LogError("Some formatted error occurred", ex, true);
                _logger.LogError("Some not formatted error occurred", ex, false);
            }

            return Countries;
        }

        /// <summary>
        /// Gets a country by Id.
        /// </summary>
        /// <returns>Returns a single country that matches the given Id.</returns>
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Countries[id];
        }

        /// <summary>
        /// Gets a country by Code.
        /// </summary>
        /// <returns>Returns a single country that matches the given country code.</returns>

        [HttpGet("{countryCode}")]
        public string Get(string code)
        {
            return Countries[0];
        }

        /// <summary>
        /// Adds a new country.
        /// </summary>
        /// <returns>Returns true, if country was added successfully.</returns>
        
        [HttpPost]
        public bool Add([FromBody] string value)
        {
            return true;
        }

        /// <summary>
        /// Updates a country.
        /// </summary>
        /// <returns>Returns true, if country was updated successfully.</returns>

        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] string value)
        {
            return true;
        }


        /// <summary>
        /// Deletes a country.
        /// </summary>
        /// <returns>Returns true, if country was deleted successfully.</returns>
        
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}
