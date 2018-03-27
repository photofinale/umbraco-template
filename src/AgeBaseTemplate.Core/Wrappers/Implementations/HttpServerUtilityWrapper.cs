using System.Web;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class HttpServerUtilityWrapper : IHttpServerUtility
    {
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}