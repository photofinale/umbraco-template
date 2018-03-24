using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.ViewModels
{
    public class LanguageSelectorViewModel
    {
        public IEnumerable<LanguagePage> Languages { get; internal set; }
        public LanguagePage Current { get; internal set; }
    }
}