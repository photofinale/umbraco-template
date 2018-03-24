using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services
{
    public interface IMasterPageService
    {
        T Create<T>(IPublishedContent content) where T : class;
    }
}