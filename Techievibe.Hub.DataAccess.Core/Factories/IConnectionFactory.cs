using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techievibe.Hub.DataAccess.Core.Factories
{
    public interface IConnectionFactory<T>
    {
        string GetConnectionString();

        T CreateConnection();

        T GetExistingConnection();
    }
}
