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
    public class CountryPageServiceTests
    {
        private Mock<IPageService> _pageService;
        private Mock<IProfileLogger> _profileLogger;
        private Mock<IUmbracoHelper> _umbracoHelper;

        private ICountryPageService _countryPageService;

        [TestInitialize]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _profileLogger = new Mock<IProfileLogger>();
            _umbracoHelper = new Mock<IUmbracoHelper>();

            var countryUkraine = new ModelsBuilderMock<CountryPage>(1);
            var countryEngland = new ModelsBuilderMock<CountryPage>(2);
            var countryGermany = new ModelsBuilderMock<CountryPage>(3);
            var countryFrance = new ModelsBuilderMock<CountryPage>(4);
            var countryItaly = new ModelsBuilderMock<CountryPage>(5);

            countryUkraine.SetProperty(c => c.CountryName, "Ukraine");
            countryEngland.SetProperty(c => c.CountryName, "England");
            countryGermany.SetProperty(c => c.CountryName, "Germany");
            countryFrance.SetProperty(c => c.CountryName, "France");
            countryItaly.SetProperty(c => c.CountryName, "Italy");

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
            var retval = _countryPageService.All();
            var countries = retval.ToList();

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
            var retval = _countryPageService.All();
            var countries = retval.ToList();
            var selected = countries.SingleOrDefault(c => c.Selected);

            Assert.IsNotNull(selected);
            Assert.AreEqual(selected.CountryName, "Ukraine");
        }
    }
}