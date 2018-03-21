using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using AgeBaseTemplate.Core.Global;
using AgeBaseTemplate.Core.Wrappers;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace AgeBaseTemplate.Core.Api
{
    [PluginController("ThemePicker")]
    public class ThemePickerApiController : UmbracoAuthorizedJsonController
    {
        private readonly IFileSystem _fileSystem;
        private readonly IHttpContext _httpContext;
        private readonly IThread _thread;

        public ThemePickerApiController(
            IFileSystem fileSystem, 
            IHttpContext httpContext,
            IThread thread)
        {
            _fileSystem = fileSystem;
            _httpContext = httpContext;
            _thread = thread;
        }

        public ThemePickerApiController()
        {
            _fileSystem = GlobalApplication.Container.GetInstance<IFileSystem>();
            _httpContext = GlobalApplication.Container.GetInstance<IHttpContext>();
            _thread = GlobalApplication.Container.GetInstance<IThread>();
        }

        public object GetThemes()
        {
            var retval = new List<object>();

            var themesPath = _httpContext.Current.Server.MapPath("~/css/");
            var themes = _fileSystem.Directory.GetDirectories(themesPath);

            foreach (var theme in themes)
            {
                var id = theme.Substring(theme.LastIndexOf("\\", StringComparison.Ordinal) + 1);

                var name = _thread.CurrentCulture.TextInfo
                    .ToTitleCase(id.Replace("-", " "))
                    .Replace("Agebase", "AgeBase");

                retval.Add(new { id, name });
            }

            return retval;
        }
    }
}