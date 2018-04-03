using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Services
{
    public interface IConfigPageService
    {
        ConfigAnalyticsPage CurrentAnalyticsPage();
        ConfigSiteContentPage CurrentSiteContentPage();
    }
}