using System.Web;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class HttpContextWrapper : IHttpContext
    {
        public bool IsDebuggingEnabled => HttpContext.Current.IsDebuggingEnabled;
    }
}