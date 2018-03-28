using System.Web.Mvc;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Services;
using DevTrends.MvcDonutCaching;

namespace AgeBaseTemplate.Core.Controllers
{
    public class HomePageController : BasePageController
    {
        private readonly IMasterPageService _masterPageService;

        public HomePageController(IMasterPageService masterPageService)
        {
            _masterPageService = masterPageService;
        }

        [DonutOutputCache(CacheProfile = "OneDay")]
        public ActionResult HomePage()
        {
            return CurrentTemplate(_masterPageService.Create<HomePage>(CurrentPage));
        }
    }
}