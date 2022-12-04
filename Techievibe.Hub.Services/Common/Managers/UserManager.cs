using Api = Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.DataAccess.Core.Providers;
using Techievibe.Hub.DataAccess.Dapper.Interfaces;
using Techievibe.Hub.Services.Common.Interfaces;
using AutoMapper;
using Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Techievibe.Hub.Logging.Core;

namespace Techievibe.Hub.Services.Common.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISumoLogger _logger;
        public UserManager(IUserRepository userRepository, IMapper mapper , IHttpContextAccessor httpContextAccessor, ISumoLogger logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<List<Api.User>> GetAllUsers()
        {
            var dataUsers = await _userRepository.GetAllAsync();

            List<Api.User> apiUsers = new List<Api.User>();

            foreach (var dbUser in dataUsers)
            {
                apiUsers.Add(_mapper.Map<Api.User>(dbUser));
            }

            return apiUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var dataUser = await _userRepository.GetByIdAsync(id);

            Api.User apiUser = new Api.User();

            //apiUser = _mapper.Map<Api.User>(dataUser);

            return apiUser;
        }
    }
}
