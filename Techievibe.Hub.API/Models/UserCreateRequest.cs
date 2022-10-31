using Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.API.Models
{
    /// <summary>
    /// Creates a request object for creating a user.
    /// </summary>
    public class UserCreateRequest
    {
        /// <summary>
        /// The user object to create.
        /// </summary>
        public User User { get; set; }
    }
}
