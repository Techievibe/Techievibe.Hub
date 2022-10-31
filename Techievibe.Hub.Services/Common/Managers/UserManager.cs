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
        public UserManager(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, ISumoLogger logger)
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

            var errors = new List<string>()
            {
                "Error 1 occurred",
                "Error 2 occurred",
                "Error 3 occurred",
                "Error 4 occurred"
            };

            throw new TechievibeException(errors, "Validation error");

            var email = apiUsers[1].Email;

            _logger.LogInfo(_httpContextAccessor.HttpContext.Items["X-Trace-Id"] + ": Inside User Manager", false);

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

            apiUser = _mapper.Map<Api.User>(dataUser);

            return apiUser;
        }
    }
}
