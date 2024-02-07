using ApiUser = Techievibe.Hub.Common.ApiModels.User;
using Techievibe.Hub.Infrastructure.Datastore.Providers;
using Techievibe.Hub.Infrastructure.Datastore.Interfaces;
using Techievibe.Hub.Services.Common.Interfaces;
using AutoMapper;
using Techievibe.Hub.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Techievibe.Hub.Infrastructure.Logging;

namespace Techievibe.Hub.Services.Common.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISumoLogger _logger;
        public UserManager(IUserRepository userRepository, IMapper mapper, ISumoLogger logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ApiUser>> GetAllUsers()
        {
            var dataUsers = await _userRepository.GetAllAsync();

            List<ApiUser> apiUsers = new();

            foreach (var dbUser in dataUsers)
            {
                apiUsers.Add(_mapper.Map<ApiUser>(dbUser));
            }

            return apiUsers;
        }

        public async Task<ApiUser> GetUserById(int id)
        {
            var dataUser = await _userRepository.GetByIdAsync(id);
                        
            ApiUser apiUser = _mapper.Map<ApiUser>(dataUser);

            return apiUser;
        }
    }
}
