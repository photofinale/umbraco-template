using AgeBaseTemplate.Core.Models;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services
{
    public interface IMasterPageService
    {
        MasterPage<T> Create<T>(IPublishedContent content) where T : class, IPublishedContent;
    }
}