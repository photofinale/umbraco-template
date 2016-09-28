using System;
using Umbraco.Core.Logging;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class LogService : ILogService
    {
        public virtual void Debug<T>(string method, string message = null, params object[] args)
        {
            string output;

            if (!string.IsNullOrWhiteSpace(message))
            {
                output = string.Format(message, args);
                output = $"{method}: {output}";
            }
            else
                output = method;

            LogHelper.Debug<T>(output);
        }

        public virtual void Error<T>(string method, Exception ex, string message = null, params object[] args)
        {
            string output;

            if (!string.IsNullOrWhiteSpace(message))
            {
                output = string.Format(message, args);
                output = $"{method}: {output}";
            }
            else
                output = method;

            LogHelper.Error<T>(output, ex);
        }
    }
}