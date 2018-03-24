using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class ContentService : IContentService
    {
        private readonly IUmbracoContext _umbracoContext;
        private readonly IUmbracoHelper _umbracoHelper;

        public ContentService(
            IUmbracoContext umbracoContext, 
            IUmbracoHelper umbracoHelper)
        {
            _umbracoContext = umbracoContext;
            _umbracoHelper = umbracoHelper;
        }

        public HomePage CurrentHomePage()
        {
            var currentPage = CurrentPage();

            var retval = currentPage?.AncestorOrSelf<HomePage>();
            if (retval != null)
            {
                return retval;
            }

            return _umbracoHelper.TypedContentSingleAtXPath($"//*[@id={currentPage?.Id}]//{HomePage.ModelTypeAlias}") as HomePage;
        }

        public IPublishedContent CurrentPage()
        {
            return _umbracoContext.Current()?.PublishedContentRequest?.PublishedContent;
        }

        public T CurrentPage<T>() where T : class
        {
            return CurrentPage() as T;
        }

        public IEnumerable<CountryPage> RootPages()
        {
            return _umbracoHelper
                .TypedContentAtXPath($"/root/{CountryPage.ModelTypeAlias}")
                .Select(c => c as CountryPage);
        }
    }
} 