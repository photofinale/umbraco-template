using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Tests.ContentTypes
{
    public class MockConfigAnalyticsPage : MockBasePage<ConfigAnalyticsPage>
    {
        public MockConfigAnalyticsPage() : this(int.MinValue)
        {
        }

        public MockConfigAnalyticsPage(int id) : base(id, "Analytics")
        {
        }
    }
}