using System;
using AgeBaseTemplate.Core.Models;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class MasterPageService : IMasterPageService
    {
        private readonly IProfileLogger _profileLogger;

        public MasterPageService(IProfileLogger profileLogger)
        {
            _profileLogger = profileLogger;
        }

        public T Create<T>(IPublishedContent content) where T : class
        {
            using (_profileLogger.TraceDuration<MasterPageService>("Create"))
            {
                var contentType = content.GetType();
                var masterType = typeof(MasterPage<>);

                var modelType = masterType.MakeGenericType(contentType);
                return Activator.CreateInstance(modelType, content) as T;
            }
        }
    }
}