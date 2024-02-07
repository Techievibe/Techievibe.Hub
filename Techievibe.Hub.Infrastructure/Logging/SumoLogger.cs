using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Techievibe.Hub.Infrastructure.Logging
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

        /// <summary>
        /// Logs an error message to SumoLogic
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location">this.GetType().Name + MethodBase.GetCurrentMethod().Name</param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        public void LogError(string message,Exception exception, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0, params object[] args)
        {
            string location = "Member Name : " + memberName + "\n" + "Path : " + sourceFilePath + "\n" + "Line Number: " + sourceLineNumber;

            if (_traceId == null || _traceId == Guid.Empty.ToString())
            {
                _traceId = Convert.ToString(_httpContextAccessor.HttpContext.Items["X-Trace-Id"]);
            }

            var logMessage = new StringBuilder();
            //logMessage.AppendLine(message);

            
            logMessage.AppendLine("******************************");
            logMessage.AppendLine("Error Message: " + message + "\n");
            logMessage.AppendLine("Exception Message : " + exception.Message);
            logMessage.AppendLine("Exception Stacktrace : " + exception.StackTrace);
            logMessage.AppendLine("Exception Source : " + exception.Source);
            logMessage.AppendLine("******************************");

            _logger.LogError("\nX-Trace-Id: " + _traceId + "\n\n" + logMessage.ToString() + "\n\n At: \n" + location, args);

        }

        /// <summary>
        /// Logs an info message to SumoLogic
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location">this.GetType().Name + MethodBase.GetCurrentMethod().Name</param>
        /// <param name="args"></param>
        public void LogInfo(string message,[System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0, params object[] args)
        {
            string location = "Member Name : " + memberName + "\n" + "Path : " + sourceFilePath + "\n" + "Line Number: " + sourceLineNumber;

            if (_traceId == null || _traceId == Guid.Empty.ToString())
            {
                _traceId = Convert.ToString(_httpContextAccessor.HttpContext.Items["X-Trace-Id"]);
            }

            var logMessage = new StringBuilder();
            //logMessage.AppendLine(message);

            
            logMessage.AppendLine("-------------------------------");
            logMessage.AppendLine(message);
            logMessage.AppendLine("-------------------------------");

            _logger.LogInformation("\nX-Trace-Id: " + _traceId + "\n\n" + logMessage.ToString() + "\n\n At: \n" + location, args);
            
        }

        /// <summary>
        /// Logs a warning message to SumoLogic
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location">this.GetType().Name + MethodBase.GetCurrentMethod().Name</param>
        /// <param name="args"></param>
        public void LogWarn(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0, params object[] args)
        {
            string location = "Member Name : " + memberName + "\n" + "Path : " + sourceFilePath + "\n" + "Line Number: " + sourceLineNumber;

            if (_traceId == null || _traceId == Guid.Empty.ToString())
            {
                _traceId = Convert.ToString(_httpContextAccessor.HttpContext.Items["X-Trace-Id"]);
            }

            var logMessage = new StringBuilder();
            //logMessage.AppendLine(message);


            logMessage.AppendLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            logMessage.AppendLine(message);
            logMessage.AppendLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            _logger.LogWarning("\nX-Trace-Id: " + _traceId + "\n\n" + logMessage.ToString() + "\n\n At: \n" + location, args);

        }


    }
}