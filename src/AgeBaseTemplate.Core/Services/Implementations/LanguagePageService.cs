using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class LanguagePageService : ILanguagePageService
    {
        private readonly ICountryPageService _countryPageService;
        private readonly IPageService _pageService;

        public LanguagePageService(
            IPageService pageService,
            ICountryPageService countryPageService)
        {
            _pageService = pageService;
            _countryPageService = countryPageService;
        }

        public IEnumerable<LanguagePage> All()
        {
            var country = _countryPageService.Current();

            var languages = country?.Children<LanguagePage>().OrderBy(l => l.LanguageName).ToList();
            if (languages == null)
            {
                return null;
            }

            foreach (var language in languages)
            {
                language.HomePageUrl = language.FirstChild<HomePage>().Url;
            }

            return languages;
        }

        public LanguagePage Current()
        {
            return _pageService.Current().AncestorOrSelf<LanguagePage>();
        }
    }
}