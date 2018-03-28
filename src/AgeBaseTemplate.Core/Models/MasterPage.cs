using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace AgeBaseTemplate.Core.Models
{
    public interface IMasterPage
    {
        string Theme { get; }
    }

    public class MasterPage<T> : RenderModel<T>, IMasterPage where T : class, IPublishedContent
    {
        public string Theme { get; internal set; }

        public MasterPage(T content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public MasterPage(T content)
            : base(content)
        {
        }
    }
}