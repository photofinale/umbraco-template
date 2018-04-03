using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class ConfigPageService : IConfigPageService
    {
        private readonly ICountryPageService _countryPageService;
        private readonly ILanguagePageService _languagePageService;
        private readonly IProfileLogger _profileLogger;
        private readonly IUmbracoHelper _umbracoHelper;

        public ConfigPageService(
            ICountryPageService countryPageService, 
            ILanguagePageService languagePageService, 
            IProfileLogger profileLogger, 
            IUmbracoHelper umbracoHelper)
        {
            _countryPageService = countryPageService;
            _languagePageService = languagePageService;
            _profileLogger = profileLogger;
            _umbracoHelper = umbracoHelper;
        }

        public ConfigAnalyticsPage CurrentAnalyticsPage()
        {
            return FindConfigPage(ConfigAnalyticsPage.ModelTypeAlias) as ConfigAnalyticsPage;
        }

        public ConfigSiteContentPage CurrentSiteContentPage()
        {
            return FindConfigPage(ConfigSiteContentPage.ModelTypeAlias) as ConfigSiteContentPage;
        }

        private IPublishedContent FindConfigPage(string docTypeAlias)
        {
            using (_profileLogger.TraceDuration<ConfigPageService>("FindConfigPage"))
            {
                var currentLanguage = _languagePageService.Current();
                if (currentLanguage != null)
                {
                    var languageSiteContentPage =
                        _umbracoHelper.TypedContentSingleAtXPath(
                                $"//*[@id={currentLanguage.Id}]//{docTypeAlias}");

                    if (languageSiteContentPage != null)
                    {
                        return languageSiteContentPage;
                    }
                }

                var currentCountry = _countryPageService.Current();
                if (currentCountry == null)
                {
                    return null;
                }

                var countrySiteConfigPage =
                    _umbracoHelper.TypedContentSingleAtXPath(
                        $"//*[@id={currentCountry.Id}]//{docTypeAlias}");

                return countrySiteConfigPage;
            }
        }
    }
}