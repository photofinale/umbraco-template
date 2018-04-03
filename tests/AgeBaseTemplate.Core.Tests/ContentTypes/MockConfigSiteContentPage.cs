using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Tests.ContentTypes
{
    public class MockConfigSiteContentPage : MockBasePage<HomePage>
    {
        public MockConfigSiteContentPage() : this(int.MinValue)
        {
        }

        public MockConfigSiteContentPage(int id) : base(id, "Site Content")
        {
        }
    }
}