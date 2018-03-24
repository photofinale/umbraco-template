using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Services
{
    public interface ILanguageService
    {
        IEnumerable<LanguagePage> All();
        LanguagePage Current();
    }
}