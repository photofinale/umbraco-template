using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Tests.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Tests.Services
{
    [TestClass]
    public class CountryPageServiceTests
    {
        private Mock<IPageService> _pageService;
        private Mock<IProfileLogger> _profileLogger;
        private Mock<IUmbracoHelper> _umbracoHelper;

        private ICountryPageService _countryPageService;

        [TestInitialize]
        public void Setup()
        {
            var countryUkraine = new MockCountryPage(1, "Ukraine");
            var countryEngland = new MockCountryPage(2, "England");
            var countryGermany = new MockCountryPage(3, "Germany");
            var countryFrance = new MockCountryPage(4, "France");
            var countryItaly = new MockCountryPage(5, "Italy");

            _pageService = new Mock<IPageService>();
            _profileLogger = new Mock<IProfileLogger>();
            _umbracoHelper = new Mock<IUmbracoHelper>();

            _pageService
                .Setup(ps => ps.Current())
                .Returns(countryUkraine.Object);

            _umbracoHelper
                .Setup(uh => uh.TypedContentAtXPath(It.IsAny<string>()))
                .Returns(new List<IPublishedContent>
                {
                    countryUkraine.Object,
                    countryEngland.Object,
                    countryGermany.Object,
                    countryFrance.Object,
                    countryItaly.Object
                });

            _countryPageService = new CountryPageService(
                _pageService.Object,
                _profileLogger.Object,
                _umbracoHelper.Object);
        }

        [TestMethod]
        public void All_GivenUnorderedCountryPages_ShouldReturnOrderedCountryPagesList()
        {
            var countries = _countryPageService.All().ToList();

            Assert.IsNotNull(countries);
            Assert.AreEqual(5, countries.Count);
            Assert.AreEqual("England", countries[0].CountryName);
            Assert.AreEqual("France", countries[1].CountryName);
            Assert.AreEqual("Germany", countries[2].CountryName);
            Assert.AreEqual("Italy", countries[3].CountryName);
            Assert.AreEqual("Ukraine", countries[4].CountryName);
        }

        [TestMethod]
        public void All_GivenCurrentCountryPage_ShouldReturnOneSelectedCountryPage()
        {
            var countries = _countryPageService.All().ToList();
            var selected = countries.Single(c => c.Selected);

            Assert.IsNotNull(selected);
            Assert.AreEqual("Ukraine", selected.CountryName);
        }
    }
}