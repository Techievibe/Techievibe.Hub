using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techievibe.Hub.DataAccess.Core.Providers
{
    public interface IDataProvider<T>
    {
        void OpenConnection(T connection);
        void CloseConnection(T connection);
        System.Data.ConnectionState GetConnectionState(T connection);

    }
}
