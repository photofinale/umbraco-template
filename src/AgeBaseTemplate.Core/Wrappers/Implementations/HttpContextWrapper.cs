using System.Web;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class HttpContextWrapper : IHttpContext
    {
        public HttpContext Current => HttpContext.Current;
    }
}