namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class HttpServerUtilityWrapper : IHttpServerUtility
    {
        private readonly IHttpContext _httpContext;

        public HttpServerUtilityWrapper(IHttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public string MapPath(string path)
        {
            return _httpContext.Current.Server.MapPath(path);
        }
    }
}