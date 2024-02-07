using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techievibe.Hub.Infrastructure.Datastore.Interfaces;
using Techievibe.Hub.Services.Common.Interfaces;

namespace Techievibe.Hub.Services.Common.Managers
{
    public class CommonManager : ICommonManager
    {
        private readonly ICommonRepository commonRepository;
        public CommonManager(ICommonRepository commonRepository)
        {
            this.commonRepository = commonRepository;
        }
        public bool CheckDbConnection()
        {
            return commonRepository.CheckDbConnection();
        }
    }
}
