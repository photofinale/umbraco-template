using System.Web.Mvc;
using AgeBaseTemplate.Core.Services;
using DevTrends.MvcDonutCaching;
using Umbraco.Web.Models;

namespace AgeBaseTemplate.Core.Controllers
{
    public class CountryPageController : BasePageController
    {
        private readonly IContentService _contentService;

        public CountryPageController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [DonutOutputCache(CacheProfile = "OneDay")]
        public override ActionResult Index(RenderModel model)
        {
            return RedirectToUmbracoPage(_contentService.CurrentHomePage());
        }
    }
}