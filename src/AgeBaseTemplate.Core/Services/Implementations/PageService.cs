using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IUmbracoContext _umbracoContext;

        public PageService(IUmbracoContext umbracoContext)
        {
            _umbracoContext = umbracoContext;
        }

        public IPublishedContent Current()
        {
            return _umbracoContext.Current.PublishedContentRequest.PublishedContent;
        }

        public T Current<T>() where T : class
        {
            return Current() as T;
        }
    }
}