using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace AgeBaseTemplate.Core.ContentTypes
{
    public partial class ConfigSiteContentPage
    {
        ///<summary>
        /// Site Theme: Select a theme that the current site will use to display.
        ///</summary>
        [ImplementPropertyType("siteTheme")]
        public string SiteTheme => this.GetPropertyValue<string>("siteTheme");
    }
}