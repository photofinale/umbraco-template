using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Services
{
    public interface ICountryService
    {
        IEnumerable<CountryPage> All();
        CountryPage Current();
    }
}