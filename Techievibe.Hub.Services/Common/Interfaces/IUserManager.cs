using Api = Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.Services.Common.Interfaces
{
    public interface IUserManager
    {
        Task<List<Api.User>> GetAllUsers();
        Task<Api.User> GetUserById(int id);
    }
}
