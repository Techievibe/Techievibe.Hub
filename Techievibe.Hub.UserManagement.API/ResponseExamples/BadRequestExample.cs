using Swashbuckle.AspNetCore.Filters;
using Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.API.ResponseExamples
{
    /// <summary>
    /// Example Response for Create new user.
    /// </summary>
    public class BadRequestExample : IExamplesProvider<ApiResponse<string>>
    {
        /// <inheritdoc/>
        public ApiResponse<string> GetExamples()
        {
            return new ApiResponse<string>(null, 400, new List<string> { "The request has invalid fields or data.", "The field \"field1\" is unknown." });
        }
    }
}
