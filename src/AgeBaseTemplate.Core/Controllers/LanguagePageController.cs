using System.Reflection;
using System.Web.Mvc;
using AgeBaseTemplate.Core.ContentTypes;
using DevTrends.MvcDonutCaching;
using log4net;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace AgeBaseTemplate.Core.Controllers
{
    public class LanguagePageController : BasePageController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [DonutOutputCache(CacheProfile = "OneDay")]
        public override ActionResult Index(RenderModel model)
        {
            var homePage = model.Content.DescendantOrSelf<HomePage>();

            Log.Debug($"Redirecting to {homePage.Id}");

            return RedirectToUmbracoPage(homePage);
        }
    }
}