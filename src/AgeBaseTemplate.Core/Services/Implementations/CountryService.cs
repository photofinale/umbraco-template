using System.Collections.Generic;
using System.Linq;
using AgeBaseTemplate.Core.ContentTypes;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly IContentService _contentService;

        public CountryService(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IEnumerable<CountryPage> All()
        {
            return _contentService.RootPages().OrderBy(c => c.CountryName);
        }

        public CountryPage Current()
        {
            return _contentService.CurrentPage().AncestorOrSelf<CountryPage>();
        }
    }
}