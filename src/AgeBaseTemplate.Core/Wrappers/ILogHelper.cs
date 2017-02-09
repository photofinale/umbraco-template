using System;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface ILogHelper
    {
        void Debug<T>(string message);

        void Error<T>(string message, Exception exception);
    }
}