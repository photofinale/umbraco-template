using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Tests.ContentTypes
{
    public class MockLanguagePage : MockBasePage<LanguagePage>
    {
        public MockLanguagePage(bool includeHomePage = false) : this(int.MinValue, string.Empty, includeHomePage)
        {
        }

        public MockLanguagePage(int id, bool includeHomePage = false) : this(id, string.Empty, includeHomePage)
        {
        }

        public MockLanguagePage(string name, bool includeHomePage = false) : this(int.MinValue, name, includeHomePage)
        {
        }

        public MockLanguagePage(int id, string name, bool includeHomePage = false) : base(id, name)
        {
            SetProperty(l => l.LanguageName, name);

            if (includeHomePage)
            {
                AddChild(new MockHomePage().Object);
            }
        }
    }
}