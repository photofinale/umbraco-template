using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class HomePageService : IHomePageService
    {
        private readonly IPageService _pageService;
        private readonly IProfileLogger _profileLogger;
        private readonly IUmbracoHelper _umbracoHelper;

        public HomePageService(
            IPageService pageService, 
            IProfileLogger profileLogger, 
            IUmbracoHelper umbracoHelper)
        {
            _pageService = pageService;
            _profileLogger = profileLogger;
            _umbracoHelper = umbracoHelper;
        }

        public HomePage Current()
        {
            using (_profileLogger.TraceDuration<HomePageService>("Current"))
            {
                var currentPage = _pageService.Current();

                var retval = currentPage.AncestorOrSelf<HomePage>();
                if (retval != null)
                {
                    return retval;
                }

                return _umbracoHelper.TypedContentSingleAtXPath($"//*[@id={currentPage.Id}]//{HomePage.ModelTypeAlias}") as HomePage;
            }
        }
    }
}