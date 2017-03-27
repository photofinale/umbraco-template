﻿using System.Linq;
using System.Web.Mvc;
using AgeBaseTemplate.Core.ContentTypes;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Controllers
{
    public class SharedController : BasePageController
    {
        [ChildActionOnly]
        public ActionResult CountrySelector()
        {
            var countryPages = Umbraco.TypedContentAtRoot()
                .Select(c => c as CountryPage)
                .Where(c => c != null)
                .OrderBy(c => c.CountryName);

            var currentCountryPage = CurrentPage.AncestorOrSelf<CountryPage>();

            countryPages.Single(c => c.Equals(currentCountryPage)).Selected = true;

            return PartialView("CountrySelector", countryPages);
        }

        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            var countryPage = CurrentPage.AncestorOrSelf<CountryPage>();

            var languagePages = countryPage.DescendantsOrSelf<LanguagePage>()
                .OrderBy(l => l.LanguageName);
            
            if (languagePages.Count() < 2)
                return Content(string.Empty);

            var currentLanguagePage = CurrentPage.AncestorOrSelf<LanguagePage>();

            languagePages.Single(l => l.Equals(currentLanguagePage)).Selected = true;

            return PartialView("LanguageSelector", languagePages);
        }
    }
}