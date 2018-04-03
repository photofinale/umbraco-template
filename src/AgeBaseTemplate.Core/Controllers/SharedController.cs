using System.Web.Mvc;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.ViewModels;

namespace AgeBaseTemplate.Core.Controllers
{
    public class SharedController : BasePageController
    {
        private readonly ICountryPageService _countryPageService;
        private readonly IGoogleAnalyticsService _googleAnalyticsService;
        private readonly ILanguagePageService _languagePageService;

        public SharedController(
            ICountryPageService countryPageService,
            IGoogleAnalyticsService googleAnalyticsService,
            ILanguagePageService languagePageService)
        {
            _countryPageService = countryPageService;
            _googleAnalyticsService = googleAnalyticsService;
            _languagePageService = languagePageService;
        }

        [ChildActionOnly]
        public ActionResult CountrySelector()
        {
            return PartialView("CountrySelector", new CountrySelectorViewModel
            {
                Countries = _countryPageService.All(),
                Current = _countryPageService.Current()
            });
        }

        [ChildActionOnly]
        public ActionResult GoogleAnalytics()
        {
            return PartialView("GoogleAnalytics", _googleAnalyticsService.CurrentTrackingId());
        }

        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            return PartialView("LanguageSelector", new LanguageSelectorViewModel
            {
                Languages = _languagePageService.All(),
                Current = _languagePageService.Current()
            });
        }
    }
}