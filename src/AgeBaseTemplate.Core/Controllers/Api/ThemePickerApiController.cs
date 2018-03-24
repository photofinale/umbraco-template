using AgeBaseTemplate.Core.Services;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace AgeBaseTemplate.Core.Controllers.Api
{
    [PluginController("ThemePicker")]
    public class ThemePickerApiController : UmbracoAuthorizedJsonController
    {
        private readonly IThemeService _themeService;

        public ThemePickerApiController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public object Themes()
        {
            return _themeService.All();
        }
    }
}