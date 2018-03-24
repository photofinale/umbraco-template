using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.ViewModels
{
    public class CountrySelectorViewModel
    {
        public IEnumerable<CountryPage> Countries { get; internal set; }
        public CountryPage Current { get; internal set; }
    }
}