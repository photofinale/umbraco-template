using System.Web.Mvc;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.ViewModels;

namespace AgeBaseTemplate.Core.Controllers
{
    public class SharedController : BasePageController
    {
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;

        public SharedController(
            ICountryService countryService,
            ILanguageService languageService)
        {
            _countryService = countryService;
            _languageService = languageService;
        }

        [ChildActionOnly]
        public ActionResult CountrySelector()
        {
            return PartialView("CountrySelector", new CountrySelectorViewModel
            {
                Countries = _countryService.All(),
                Current = _countryService.Current()
            });
        }

        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            return PartialView("LanguageSelector", new LanguageSelectorViewModel
            {
                Languages = _languageService.All(),
                Current = _languageService.Current()
            });
        }
    }
}