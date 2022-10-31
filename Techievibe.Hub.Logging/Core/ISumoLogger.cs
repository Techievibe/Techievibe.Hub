using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techievibe.Hub.Logging.Core
{
    public interface ISumoLogger
    {
        void LogInfo(string message, bool isFormatted, params object[] args);

        void LogError(string message, Exception exception, bool isFormatted, params object[] args);
    }
}
