using Umbraco.Web;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface IUmbracoContext
    {
        UmbracoContext Current();
    }
}