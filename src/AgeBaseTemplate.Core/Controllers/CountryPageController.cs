using System.Web.Mvc;
using AgeBaseTemplate.Core.Services;
using DevTrends.MvcDonutCaching;
using Umbraco.Web.Models;

namespace AgeBaseTemplate.Core.Controllers
{
    public class CountryPageController : BasePageController
    {
        private readonly IHomePageService _homePageService;

        public CountryPageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        [DonutOutputCache(CacheProfile = "OneDay")]
        public override ActionResult Index(RenderModel model)
        {
            return RedirectToUmbracoPage(_homePageService.Current());
        }
    }
}