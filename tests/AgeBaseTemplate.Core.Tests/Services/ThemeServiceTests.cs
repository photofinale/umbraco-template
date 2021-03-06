﻿using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Threading;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeBaseTemplate.Core.Tests.Services
{
    [TestClass]
    public class ThemeServiceTests
    {
        private Mock<ICultureInfo> _cultureInfo;
        private MockFileSystem _fileSystem;
        private Mock<IHttpServerUtility> _httpServerUtility;
        private Mock<IProfileLogger> _profileLogger;

        private IThemeService _themeService;

        [TestInitialize]
        public void Setup()
        {
            _cultureInfo = new Mock<ICultureInfo>();
            _httpServerUtility = new Mock<IHttpServerUtility>();
            _profileLogger = new Mock<IProfileLogger>();

            _cultureInfo.Setup(ci => ci.CurrentCulture).Returns(Thread.CurrentThread.CurrentCulture);

            _fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {
                    @"c:\themes\agebase-template\theme.txt",
                    new MockFileData(string.Empty)
                },
                {
                    @"c:\themes\agebase-template-dark\theme.txt",
                    new MockFileData(string.Empty)
                },
                {
                    @"c:\themes\agebase-template-high-contrast\theme.txt",
                    new MockFileData(string.Empty)
                }
            });

            _httpServerUtility.Setup(hsu => hsu.MapPath(It.IsAny<string>())).Returns(@"c:\themes");

            _themeService = new ThemeService(
                _cultureInfo.Object,
                _fileSystem,
                _httpServerUtility.Object,
                _profileLogger.Object);
        }

        [TestMethod]
        public void All_GivenAgeBaseTheme_ShouldReturnCorrectFormattingOfAgeBase()
        {
            var retval = _themeService.All();
            var themes = retval?.ToList();

            Assert.IsNotNull(themes);
            Assert.AreEqual(3, themes.Count);
            Assert.AreEqual("AgeBase Template", themes[0].Name);
            Assert.AreEqual("AgeBase Template Dark", themes[1].Name);
            Assert.AreEqual("AgeBase Template High Contrast", themes[2].Name);
        }
    }
}