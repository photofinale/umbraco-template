﻿using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class CountryPageService : ICountryPageService
    {
        private readonly IPageService _pageService;
        private readonly IProfileLogger _profileLogger;
        private readonly IUmbracoHelper _umbracoHelper;

        public CountryPageService(
            IPageService pageService,
            IProfileLogger profileLogger,
            IUmbracoHelper umbracoHelper)
        {
            _pageService = pageService;
            _profileLogger = profileLogger;
            _umbracoHelper = umbracoHelper;
        }

        public IEnumerable<CountryPage> All()
        {
            using (_profileLogger.TraceDuration<CountryPageService>("All"))
            {
                return _umbracoHelper
                    .TypedContentAtXPath($"/root/{CountryPage.ModelTypeAlias}")
                    .Select(c => c as CountryPage)
                    .Where(c => c != null)
                    .OrderBy(c => c.CountryName);
            }
        }

        public CountryPage Current()
        {
            using (_profileLogger.TraceDuration<CountryPageService>("Current"))
            {
                return _pageService.Current().AncestorOrSelf<CountryPage>();
            }
        }
    }
}