using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Techievibe.Hub.Logging.Core
{
    internal class SumoLogger : ISumoLogger
    {
        private readonly ILogger<SumoLogger> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _traceId = Guid.Empty.ToString();
        public SumoLogger(ILogger<SumoLogger> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void LogError(string message, Exception exception, bool isFormatted, params object[] args)
        {
            if (_traceId == null || _traceId == Guid.Empty.ToString())
            {
                _traceId = Convert.ToString(_httpContextAccessor.HttpContext.Items["X-Trace-Id"]);
            }

            var logMessage = new StringBuilder();
            //logMessage.AppendLine(message);

            if (isFormatted)
            {
                logMessage.AppendLine("******************************");
                logMessage.AppendLine(message);
                logMessage.AppendLine();
                logMessage.AppendLine();
                logMessage.AppendLine("Exception Details : ");
                logMessage.AppendLine("Exception Message : " + exception.Message);
                logMessage.AppendLine("Exception Stacktrace : " + exception.StackTrace);
                logMessage.AppendLine("Exception Source : " + exception.Source);
                logMessage.AppendLine("******************************");

                _logger.LogError("X-Trace-Id: " + _traceId + " " + logMessage.ToString(), args);

                return;
            }

            _logger.LogError("X-Trace-Id: " + _traceId + " " + message);
        }

        public void LogInfo(string message, bool isFormatted, params object[] args)
        {
            var logMessage = new StringBuilder();
            //logMessage.AppendLine(message);

            if (isFormatted)
            {
                logMessage.AppendLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                logMessage.AppendLine(message);
                logMessage.AppendLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                _logger.LogInformation("X-Trace-Id: " + _traceId + " " + logMessage.ToString(), args);

                return;
            }

            _logger.LogInformation("X-Trace-Id: " + _traceId + " " + message);
        }


    }
}