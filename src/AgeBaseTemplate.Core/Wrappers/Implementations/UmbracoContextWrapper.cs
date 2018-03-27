using Umbraco.Web;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class UmbracoContextWrapper : IUmbracoContext
    {
        public UmbracoContext Current => UmbracoContext.Current;
    }
}