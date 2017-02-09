using System;
using Umbraco.Core.Logging;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class LogHelperWrapper : ILogHelper
    {
        public void Debug<T>(string message)
        {
            LogHelper.Debug<T>(message);
        }

        public void Error<T>(string message, Exception exception)
        {
            LogHelper.Error<T>(message, exception);
        }
    }
}