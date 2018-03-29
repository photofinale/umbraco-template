using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Moq;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Tests.Mocks
{
    public abstract class MockBasePage<T> where T : IPublishedContent
    {
        protected readonly Mock<IPublishedContent> PublishedContent;

        public T Object { get; }

        protected MockBasePage(int id, string name)
        {
            PublishedContent = new Mock<IPublishedContent>();
            PublishedContent.Setup(pc => pc.Id).Returns(id);
            PublishedContent.Setup(pc => pc.Name).Returns(name);
            PublishedContent.Setup(pc => pc.Url).Returns(string.Empty);

            Object = CreateObjectWithAnyConstructor<T>(PublishedContent.Object);
        }

        public void AddChild(IPublishedContent child)
        {
            var children = PublishedContent.Object?.Children?.ToList() ?? new List<IPublishedContent>();
            children.Add(child);

            PublishedContent.Setup(pc => pc.Children).Returns(children);
        }

        public void SetProperty(Expression<Func<T, object>> propertyExpression, object value)
        {
            var propertyName = ExpressionHelper.GetExpressionText(propertyExpression);
            propertyName = $"{propertyName[0].ToString().ToLower()}{propertyName.Substring(1)}";

            var mockedProperty = new Mock<IPublishedProperty>();

            PublishedContent.Setup(pc => pc.GetProperty(propertyName, false)).Returns(mockedProperty.Object);

            mockedProperty.SetupAllProperties();
            mockedProperty.SetupGet(mp => mp.Value).Returns(value);
            mockedProperty.SetupGet(mp => mp.HasValue).Returns(true);
        }

        public static T CreateObjectWithAnyConstructor<T>(params object[] parameters)
        {
            return (T) CreateObjectWithAnyConstructor(typeof(T), parameters);
        }

        public static object CreateObjectWithAnyConstructor(Type typeToCreate, params object[] parameters)
        {
            var constructor = typeToCreate
                .GetConstructors()
                .FirstOrDefault(x => x.GetParameters().Length == parameters.Length);

            if (constructor == null || constructor.IsAssembly)
            {
                throw new InvalidOperationException($"A private or protected constructor is missing for '{typeToCreate.Name}'.");
            }

            object instance;
            try
            {
                instance = constructor.Invoke(parameters);
            }
            catch (MemberAccessException ex)
            {
                var m = Regex.Match(ex.Message, "Cannot create an instance of (.*?)Factory because it is an abstract class.");

                if (!m.Success)
                {
                    throw;
                }

                var msg = $"{ex.Message} - If you are using this factory, make sure you mark it as \'UsedInProject\' in the builder";

                throw new InvalidOperationException(msg);
            }

            return instance;
        }
    }
}