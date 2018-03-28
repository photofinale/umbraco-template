using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Tests.Mocks;
using AgeBaseTemplate.Core.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Umbraco.Core.Models;

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
            _countryPageService = new Mock<ICountryPageService>();
            _pageService = new Mock<IPageService>();
            _profileLogger = new Mock<IProfileLogger>();

            var languageFrench = new ModelsBuilderMock<LanguagePage>(1);
            var langaugeDutch = new ModelsBuilderMock<LanguagePage>(2);
            var languageArabic = new ModelsBuilderMock<LanguagePage>(3);
            
            languageFrench.SetProperty(l => l.LanguageName, "French");
            languageFrench.SetChildren(new List<IPublishedContent>
            {
                new ModelsBuilderMock<HomePage>(4).Object
            });

            langaugeDutch.SetProperty(l => l.LanguageName, "Dutch");
            langaugeDutch.SetChildren(new List<IPublishedContent>
            {
                new ModelsBuilderMock<HomePage>(5).Object
            });

            languageArabic.SetProperty(l => l.LanguageName, "Arabic");
            languageArabic.SetChildren(new List<IPublishedContent>
            {
                new ModelsBuilderMock<HomePage>(6).Object
            });

            var country = new ModelsBuilderMock<CountryPage>(7);

            country.SetChildren(new List<IPublishedContent>
            {
                languageFrench.Object,
                langaugeDutch.Object,
                languageArabic.Object
            });

            _countryPageService.Setup(ps => ps.Current()).Returns(country.Object);

            _pageService.Setup(ps => ps.Current()).Returns(langaugeDutch.Object);

            _languagePageService = new LanguagePageService(
                _countryPageService.Object,
                _pageService.Object,
                _profileLogger.Object);
        }

        [TestMethod]
        public void All_GivenUnorderedlanguagePages_ShouldReturnOrderedLanguagePagesList()
        {
            var retval = _languagePageService.All();
            var languages = retval.ToList();

            Assert.IsNotNull(languages);
            Assert.AreEqual(3, languages.Count);
            Assert.AreEqual("Arabic", languages[0].LanguageName);
            Assert.AreEqual("Dutch", languages[1].LanguageName);
            Assert.AreEqual("French", languages[2].LanguageName);
        }

        [TestMethod]
        public void All_GivenCurrentLanguagePage_ShouldReturnOneSelectedLanguagePage()
        {
            var retval = _languagePageService.All();
            var languages = retval.ToList();
            var selected = languages.SingleOrDefault(c => c.Selected);

            Assert.IsNotNull(selected);
            Assert.AreEqual(selected.LanguageName, "Dutch");
        }
    }
}