using System.Web.Mvc;
using AgeBaseTemplate.Core.Services;
using DevTrends.MvcDonutCaching;
using Umbraco.Web.Models;

namespace AgeBaseTemplate.Core.Controllers
{
    public class LanguagePageController : BasePageController
    {
        private readonly IContentService _contentService;

        public LanguagePageController(IContentService contentService)
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