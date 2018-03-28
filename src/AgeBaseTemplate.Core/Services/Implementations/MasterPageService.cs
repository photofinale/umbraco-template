using System;
using AgeBaseTemplate.Core.Models;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class MasterPageService : IMasterPageService
    {
        private readonly IConfigPageService _configPageService;
        private readonly IProfileLogger _profileLogger;

        public MasterPageService(
            IConfigPageService configPageService, 
            IProfileLogger profileLogger)
        {
            _configPageService = configPageService;
            _profileLogger = profileLogger;
        }

        MasterPage<T> IMasterPageService.Create<T>(IPublishedContent content)
        {
            using (_profileLogger.TraceDuration<MasterPageService>("Create"))
            {
                var contentType = content.GetType();
                var masterType = typeof(MasterPage<>);

                var modelType = masterType.MakeGenericType(contentType);

                if (!(Activator.CreateInstance(modelType, content) is MasterPage<T> retval))
                {
                    return null;
                }

                retval.Theme = _configPageService.CurrentSiteContentPage()?.SiteTheme;
                return retval;
            }
        }
    }
}