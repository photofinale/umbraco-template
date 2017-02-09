using System;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using AgeBaseTemplate.Core.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeBaseTemplate.Core.Tests.Services
{
    [TestClass]
    public class LogServiceTests
    {
        private Mock<ILogHelper> _logHelper;
        private ILogService _logService;

        [TestInitialize]
        public void Setup()
        {
            _logHelper = new Mock<ILogHelper>();
            _logService = new LogService(_logHelper.Object);
        }

        [TestMethod]
        public void Debug_GivenMethodAndMessage_ReturnsMethodAndMessage()
        {
            // Assign
            string output = null;

            _logHelper
                .Setup(l => l.Debug<object>(It.IsAny<string>()))
                .Callback<string>(r => output = r);

            // Act
            _logService.Debug<object>("Name", "Lorem Ipsum");

            // Assert
            Assert.AreEqual("Name: Lorem Ipsum", output);
        }

        [TestMethod]
        public void Debug_GivenMethodAndMessageWithBraces_ReturnsMethodAndMessageWithEscapedBraces()
        {
            // Assign
            string output = null;

            _logHelper
                .Setup(l => l.Debug<object>(It.IsAny<string>()))
                .Callback<string>(c => output = c);

            // Act
            _logService.Debug<object>("Name", "Lorem Ipsum { json }");

            // Assert
            Assert.AreEqual("Name: Lorem Ipsum {{ json }}", output);
        }

        [TestMethod]
        public void Error_GivenMethodAndException_ReturnsMethodAndException()
        {
            // Assign
            var exception = new Exception();
            string output = null;

            _logHelper
                .Setup(l => l.Error<object>(It.IsAny<string>(), It.IsAny<Exception>()))
                .Callback<string, Exception>((s, e) => output = s);

            // Act
            _logService.Error<object>("Name", exception);

            // Assert
            Assert.AreEqual("Name", output);
        }

        [TestMethod]
        public void Error_GivenMethodMessageAndException_ReturnsMethodMessageAndException()
        {
            // Assign
            var exception = new Exception();
            string output = null;

            _logHelper
                .Setup(l => l.Error<object>(It.IsAny<string>(), It.IsAny<Exception>()))
                .Callback<string, Exception>((s, e) => output = s);

            // Act
            _logService.Error<object>("Name", exception, "Lorem Ipsum");

            // Assert
            Assert.AreEqual("Name: Lorem Ipsum", output);
        }

        [TestMethod]
        public void Error_GivenMethodMessageAndExceptionWithBraces_ReturnsMethodMessageAndExceptionWithBraces()
        {
            // Assign
            var exception = new Exception();
            string output = null;

            _logHelper
                .Setup(l => l.Error<object>(It.IsAny<string>(), It.IsAny<Exception>()))
                .Callback<string, Exception>((s, e) => output = s);

            // Act
            _logService.Error<object>("Name", exception, "Lorem Ipsum { json }");

            // Assert
            Assert.AreEqual("Name: Lorem Ipsum {{ json }}", output);
        }
    }
}