using System;
using AgeBaseTemplate.Core.Wrappers;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class LogService : ILogService
    {
        private readonly ILogHelper _logHelper;

        public LogService(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        public virtual void Debug<T>(string method, string message = null)
        {
            var output = !string.IsNullOrWhiteSpace(message) 
                ? $"{method}: {message}" 
                : method;

            output = output.Replace("{", "{{").Replace("}", "}}");

            _logHelper.Debug<T>(output);
        }

        public virtual void Error<T>(string method, Exception ex, string message = null)
        {
            var output = !string.IsNullOrWhiteSpace(message) 
                ? $"{method}: {message}"
                : method;

            output = output.Replace("{", "{{").Replace("}", "}}");

            _logHelper.Error<T>(output, ex);
        }
    }
}