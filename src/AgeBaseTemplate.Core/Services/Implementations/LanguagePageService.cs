﻿using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class LanguagePageService : ILanguagePageService
    {
        private readonly ICountryPageService _countryPageService;
        private readonly IPageService _pageService;
        private readonly IProfileLogger _profileLogger;

        public LanguagePageService(
            IPageService pageService,
            ICountryPageService countryPageService, 
            IProfileLogger profileLogger)
        {
            _pageService = pageService;
            _countryPageService = countryPageService;
            _profileLogger = profileLogger;
        }

        public IEnumerable<LanguagePage> All()
        {
            using (_profileLogger.TraceDuration<LanguagePageService>("All"))
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
        }

        public LanguagePage Current()
        {
            using (_profileLogger.TraceDuration<LanguagePageService>("Current"))
            {
                return _pageService.Current().AncestorOrSelf<LanguagePage>();
            }
        }
    }
}