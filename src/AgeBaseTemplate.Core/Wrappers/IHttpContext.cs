using System.Web;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface IHttpContext
    {
        HttpContext Current { get; }
    }
}