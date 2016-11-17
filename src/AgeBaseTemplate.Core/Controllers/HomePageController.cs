using System.Web.Mvc;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Models.Implementations;
using AgeBaseTemplate.Core.Services;

namespace AgeBaseTemplate.Core.Controllers
{
    public class HomePageController : BasePageController
    {
        private readonly ILogService _logService;
        private readonly IMasterPageService _masterPageService;

        public HomePageController(ILogService logService, IMasterPageService masterPageService)
        {
            _logService = logService;
            _masterPageService = masterPageService;
        }
        
        public ActionResult HomePage()
        {
            _logService.Debug<HomePageController>("HomePage");

            var model = _masterPageService.CreateModel<MasterPage<HomePage>>(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}