using AgeBaseTemplate.Core.Wrappers;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class GoogleAnalyticsService : IGoogleAnalyticsService
    {
        private readonly IConfigPageService _configPageService;
        private readonly IHttpContext _httpContext;
        private readonly IProfileLogger _profileLogger;

        public GoogleAnalyticsService(
            IConfigPageService configPageService, 
            IHttpContext httpContext,
            IProfileLogger profileLogger)
        {
            _configPageService = configPageService;
            _httpContext = httpContext;
            _profileLogger = profileLogger;
        }

        public string CurrentTrackingId()
        {
            using (_profileLogger.TraceDuration<GoogleAnalyticsService>("CurrentTrackingId"))
            {
                return _httpContext.IsDebuggingEnabled
                    ? null
                    : _configPageService.CurrentAnalyticsPage()?.GoogleAnalytics;
            }
        }
    }
}