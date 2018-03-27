using System.Collections.Generic;
using AgeBaseTemplate.Core.ContentTypes;

namespace AgeBaseTemplate.Core.Services
{
    public interface ILanguagePageService
    {
        IEnumerable<LanguagePage> All();
        LanguagePage Current();
    }
}