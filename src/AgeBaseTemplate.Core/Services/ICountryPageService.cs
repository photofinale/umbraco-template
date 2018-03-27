using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Services
{
    public interface ICountryPageService
    {
        IEnumerable<CountryPage> All();
        CountryPage Current();
    }
}