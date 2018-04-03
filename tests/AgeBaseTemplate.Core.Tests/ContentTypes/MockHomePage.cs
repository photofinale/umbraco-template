using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Tests.ContentTypes
{
    public class MockHomePage : MockBasePage<HomePage>
    {
        public MockHomePage() : this(int.MinValue, string.Empty)
        {
        }

        public MockHomePage(int id) : this(id, string.Empty)
        {
        }

        public MockHomePage(string name) : this(int.MinValue, name)
        {
        }

        public MockHomePage(int id, string name) : base(id, name)
        {
        }
    }
}