using Swashbuckle.AspNetCore.Filters;
using Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.API.ResponseExamples
{
    /// <summary>
    /// Example Response for Create new user.
    /// </summary>
    public class ForbiddenRequestExample : IExamplesProvider<ApiResponse<string>>
    {
        /// <inheritdoc/>
        public ApiResponse<string> GetExamples()
        {
            return new ApiResponse<string>(null, 403, new List<string> { "The user is forbidden from performing this action. " });
        }
    }
}
