using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services
{
    public interface IContentService
    {
        HomePage CurrentHomePage();
        IPublishedContent CurrentPage();
        T CurrentPage<T>() where T : class;
        IEnumerable<CountryPage> RootPages();
    }
}