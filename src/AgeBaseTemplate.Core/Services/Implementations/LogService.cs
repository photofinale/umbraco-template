using System;
using Umbraco.Core.Logging;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class LogService : ILogService
    {
        public virtual void Debug<T>(string method, string message = null)
        {
            var output = !string.IsNullOrWhiteSpace(message) 
                ? $"{method}: {message}" 
                : method;

            output = output.Replace("{", "{{").Replace("}", "}}");

            LogHelper.Debug<T>(output);
        }

        public virtual void Error<T>(string method, Exception ex, string message = null)
        {
            var output = !string.IsNullOrWhiteSpace(message) 
                ? $"{method}: {message}"
                : method;

            output = output.Replace("{", "{{").Replace("}", "}}");

            LogHelper.Error<T>(output, ex);
        }
    }
}