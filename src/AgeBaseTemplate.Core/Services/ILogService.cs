using System;

namespace AgeBaseTemplate.Core.Services
{
    public interface ILogService
    {
        void Debug<T>(string method, string message = null, params object[] args);

        void Error<T>(string method, Exception ex, string message = null, params object[] args);
    }
}