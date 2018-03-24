using System.Collections.Generic;
using AgeBaseTemplate.Core.Global;
using AgeBaseTemplate.Core.Models;
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

        public ThemePickerApiController()
        {
            _themeService = GlobalApplication.Container.GetInstance<IThemeService>();
        }

        public IEnumerable<Theme> GetThemes()
        {
            return _themeService.All();
        }
    }
}