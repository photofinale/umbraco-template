using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class CountryPageService : ICountryPageService
    {
        private readonly IPageService _pageService;
        private readonly IUmbracoHelper _umbracoHelper;

        public CountryPageService(IPageService contentService, IUmbracoHelper umbracoHelper)
        {
            _pageService = contentService;
            _umbracoHelper = umbracoHelper;
        }

        public IEnumerable<CountryPage> All()
        {
            return _umbracoHelper
                .TypedContentAtXPath($"/root/{CountryPage.ModelTypeAlias}")
                .Select(c => c as CountryPage)
                .Where(c => c != null)
                .OrderBy(c => c.CountryName);
        }

        public CountryPage Current()
        {
            return _pageService.Current().AncestorOrSelf<CountryPage>();
        }
    }
}