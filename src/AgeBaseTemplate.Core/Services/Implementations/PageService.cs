using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IProfileLogger _profileLogger;
        private readonly IUmbracoContext _umbracoContext;

        public PageService(
            IProfileLogger profileLogger, 
            IUmbracoContext umbracoContext)
        {
            _profileLogger = profileLogger;
            _umbracoContext = umbracoContext;
        }

        public IPublishedContent Current()
        {
            using (_profileLogger.TraceDuration<PageService>("Current"))
            {
                return _umbracoContext.Current.PublishedContentRequest.PublishedContent;
            }
        }

        public T Current<T>() where T : class
        {
            using (_profileLogger.TraceDuration<PageService>("Current<T>"))
            {
                return Current() as T;
            }
        }
    }
}