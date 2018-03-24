using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly IContentService _contentService;
        private readonly ICountryService _countryService;

        public LanguageService(
            IContentService contentService, 
            ICountryService countryService)
        {
            _contentService = contentService;
            _countryService = countryService;
        }

        public IEnumerable<LanguagePage> All()
        {
            var country = _countryService.Current();

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
            return _contentService.CurrentPage().AncestorOrSelf<LanguagePage>();
        }
    }
}