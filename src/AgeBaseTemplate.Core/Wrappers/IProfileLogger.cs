using Umbraco.Core;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface IProfileLogger
    {
        DisposableTimer TraceDuration<T>(string startMessage);
    }
}