using Umbraco.Core;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class ProfileLoggerWrapper : IProfileLogger
    {
        public DisposableTimer TraceDuration<T>(string startMessage)
        {
            return UmbracoContext.Current.Application.ProfilingLogger.TraceDuration<T>(startMessage);
        }
    }
}