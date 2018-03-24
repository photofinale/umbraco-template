using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace AgeBaseTemplate.Core.Models
{
    public class MasterPage<T> : RenderModel<T> where T : class, IPublishedContent
    {
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