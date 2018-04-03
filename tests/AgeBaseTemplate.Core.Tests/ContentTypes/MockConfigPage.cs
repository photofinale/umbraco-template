using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Tests.ContentTypes
{
    public class MockConfigPage : MockBasePage<ConfigPage>
    {
        public MockConfigPage() : this(int.MinValue)
        {
        }

        public MockConfigPage(int id) : base(id, "Configuration")
        {
            AddChild(new MockConfigAnalyticsPage().Object);
            AddChild(new MockConfigSiteContentPage().Object);
        }
    }
}