using System;
using System.Reflection;
using AgeBaseTemplate.Core.Models.Implementations;
using log4net;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class MasterPageService : IMasterPageService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public T CreateModel<T>(IPublishedContent content) where T : class
        {
            Log.Debug($"Converting {content.Id} to a MasterPage class");

            var contentType = content.GetType();
            var masterType = typeof(MasterPage<>);

            var modelType = masterType.MakeGenericType(contentType);
            return Activator.CreateInstance(modelType, content) as T;
        }
    }
}