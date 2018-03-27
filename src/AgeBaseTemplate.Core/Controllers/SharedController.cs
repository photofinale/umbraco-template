using System.Web.Mvc;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.ViewModels;

namespace AgeBaseTemplate.Core.Controllers
{
    public class SharedController : BasePageController
    {
        private readonly ICountryPageService _countryPageService;
        private readonly ILanguagePageService _languagePageService;

        public SharedController(
            ICountryPageService countryPageService,
            ILanguagePageService languagePageService)
        {
            _countryPageService = countryPageService;
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