using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services
{
    public interface IPageService
    {
        IPublishedContent Current();
        T Current<T>() where T : class;
    }
}