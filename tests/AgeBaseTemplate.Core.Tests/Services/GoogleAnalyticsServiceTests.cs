using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Tests.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeBaseTemplate.Core.Tests.Services
{
    [TestClass]
    public class GoogleAnalyticsServiceTests
    {
        private Mock<IConfigPageService> _configPageService;
        private Mock<IHttpContext> _httpContext;
        private Mock<IProfileLogger> _profileLogger;

        private IGoogleAnalyticsService _googleAnalyticsService;

        [TestInitialize]
        public void Setup()
        {
            _configPageService = new Mock<IConfigPageService>();
            _httpContext = new Mock<IHttpContext>();
            _profileLogger = new Mock<IProfileLogger>();

            var configAnalyticsPage = new MockConfigAnalyticsPage();
            configAnalyticsPage.SetProperty(cap => cap.GoogleAnalytics, "UA-123456789-0");

            _configPageService.Setup(cps => cps.CurrentAnalyticsPage()).Returns(configAnalyticsPage.Object);

            _httpContext.Setup(hc => hc.IsDebuggingEnabled).Returns(false);

            _googleAnalyticsService = new GoogleAnalyticsService(
                _configPageService.Object,
                _httpContext.Object,
                _profileLogger.Object);
        }

        [TestMethod]
        public void CurrentTrackingId_GivenConfigAnalyticsPages_ShouldReturnTrackingId()
        {
            var trackingId = _googleAnalyticsService.CurrentTrackingId();

            Assert.IsNotNull(trackingId);
            Assert.AreEqual("UA-123456789-0", trackingId);
        }

        [TestMethod]
        public void CurrentTrackingId_GivenEnabledDebuggingHttpContext_ShouldReturnNullString()
        {
            _httpContext.Setup(hc => hc.IsDebuggingEnabled).Returns(true);

            Assert.IsNull(_googleAnalyticsService.CurrentTrackingId());
        }
    }
}