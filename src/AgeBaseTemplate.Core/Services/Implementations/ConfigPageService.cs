using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;

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

        public ConfigSiteContentPage CurrentSiteContentPage()
        {
            using (_profileLogger.TraceDuration<ConfigPageService>("CurrentSiteContentPage"))
            {
                var currentLanguage = _languagePageService.Current();
                if (currentLanguage != null)
                {
                    var languageSiteContentPage =
                        _umbracoHelper.TypedContentSingleAtXPath(
                                $"//*[@id={currentLanguage.Id}]//{ConfigSiteContentPage.ModelTypeAlias}");

                    if (languageSiteContentPage != null)
                    {
                        return languageSiteContentPage as ConfigSiteContentPage;
                    }
                }

                var currentCountry = _countryPageService.Current();
                if (currentCountry == null)
                {
                    return null;
                }

                var countrySiteConfigPage =
                    _umbracoHelper.TypedContentSingleAtXPath(
                        $"//*[@id={currentCountry.Id}]//{ConfigSiteContentPage.ModelTypeAlias}");

                return countrySiteConfigPage as ConfigSiteContentPage;
            }
        }
    }
}