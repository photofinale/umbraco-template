using System.Linq;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Tests.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeBaseTemplate.Core.Tests.Services
{
    [TestClass]
    public class LanguagePageServiceTests
    {
        private Mock<ICountryPageService> _countryPageService;
        private Mock<IPageService> _pageService;
        private Mock<IProfileLogger> _profileLogger;

        private ILanguagePageService _languagePageService;

        [TestInitialize]
        public void Setup()
        {
            var selected = new MockLanguagePage(1, "Dutch", true);

            var country = new MockCountryPage()
                .WithLanguagePage(new MockLanguagePage(2, "French", true))
                .WithLanguagePage(selected)
                .WithLanguagePage(new MockLanguagePage(3, "Arabic", true));

            _countryPageService = new Mock<ICountryPageService>();
            _pageService = new Mock<IPageService>();
            _profileLogger = new Mock<IProfileLogger>();

            _countryPageService.Setup(ps => ps.Current()).Returns(country.Object);

            _pageService.Setup(ps => ps.Current()).Returns(selected.Object);

            _languagePageService = new LanguagePageService(
                _countryPageService.Object,
                _pageService.Object,
                _profileLogger.Object);
        }

        [TestMethod]
        public void All_GivenUnorderedlanguagePages_ShouldReturnOrderedLanguagePagesList()
        {
            var languages = _languagePageService.All().ToList();

            Assert.IsNotNull(languages);
            Assert.AreEqual(3, languages.Count);
            Assert.AreEqual("Arabic", languages[0].LanguageName);
            Assert.AreEqual("Dutch", languages[1].LanguageName);
            Assert.AreEqual("French", languages[2].LanguageName);
        }

        [TestMethod]
        public void All_GivenCurrentLanguagePage_ShouldReturnOneSelectedLanguagePage()
        {
            var languages = _languagePageService.All().ToList();
            var selected = languages.Single(c => c.Selected);

            Assert.IsNotNull(selected);
            Assert.AreEqual("Dutch", selected.LanguageName);
        }
    }
}