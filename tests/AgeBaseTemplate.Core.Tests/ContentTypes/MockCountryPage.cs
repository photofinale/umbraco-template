using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Tests.ContentTypes
{
    public class MockCountryPage : MockBasePage<CountryPage>
    {
        public MockCountryPage() : this(int.MinValue, string.Empty)
        {
        }

        public MockCountryPage(int id) : this(id, string.Empty)
        {
        }

        public MockCountryPage(string name) : this(int.MinValue, name)
        {
        }

        public MockCountryPage(int id, string name) : base(id, name)
        {
            SetProperty(c => c.CountryName, name);
        }

        public MockCountryPage WithLanguagePage(MockLanguagePage mockLanguagePage)
        {
            AddChild(mockLanguagePage.Object);
            return this;
        }
    }
}