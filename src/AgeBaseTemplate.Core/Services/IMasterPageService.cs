using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services
{
    public interface IMasterPageService
    {
        T CreateModel<T>(IPublishedContent content) where T : class;
    }
}