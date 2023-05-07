using Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.API.Models
{
    /// <summary>
    /// A request object for updating an existing user in the system
    /// </summary>
    public class UserUpdateRequest
    {
        /// <summary>
        /// The user object to update.
        /// </summary>
        public User User { get; set; }
    }
}
