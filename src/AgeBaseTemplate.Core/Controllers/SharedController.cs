using System.Linq;
using System.Web.Mvc;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.ViewModels;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Controllers
{
    public class SharedController : BasePageController
    {
        [ChildActionOnly]
        public ActionResult CountrySelector()
        {
            var model = new CountrySelectorViewModel
            {
                Countries = Umbraco.TypedContentAtRoot()
                    .Select(c => c as CountryPage)
                    .Where(c => c != null)
                    .OrderBy(c => c.CountryName),

                Current = CurrentPage.AncestorOrSelf<CountryPage>()
            };

            return PartialView("CountrySelector", model);
        }

        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            var countryPage = CurrentPage.AncestorOrSelf<CountryPage>();
            
            var model = new LanguageSelectorViewModel
            {
                Languages = countryPage
                    .Children<LanguagePage>()
                    .OrderBy(l => l.LanguageName),

                Current = CurrentPage.AncestorOrSelf<LanguagePage>()
            };

            if (model.Languages.Count() < 2)
                return Content(string.Empty);

            // Here we are using the home page url,
            // not the language page url

            foreach (var language in model.Languages)
            {
                language.HomePageUrl = language.FirstChild<HomePage>().Url;
            }

            return PartialView("LanguageSelector", model);
        }
    }
}