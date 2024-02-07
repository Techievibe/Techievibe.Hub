using Swashbuckle.AspNetCore.Filters;
using Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.API.ResponseExamples
{
    /// <summary>
    /// Example Response for Create new user.
    /// </summary>
    public class CreateNewUserExample : IExamplesProvider<ApiResponse<string>>
    {
        /// <inheritdoc/>
        public ApiResponse<string> GetExamples()
        {
            return new ApiResponse<string>(Guid.NewGuid().ToString(), 201, null);
        }
    }
}
