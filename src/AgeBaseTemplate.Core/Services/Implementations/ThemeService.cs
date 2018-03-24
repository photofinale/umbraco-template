using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using AgeBaseTemplate.Core.Models;
using AgeBaseTemplate.Core.Wrappers;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class ThemeService : IThemeService
    {
        private readonly IFileSystem _fileSystem;
        private readonly IHttpContext _httpContext;
        private readonly IThread _thread;

        public ThemeService(
            IFileSystem fileSystem, 
            IHttpContext httpContext, 
            IThread thread)
        {
            _fileSystem = fileSystem;
            _httpContext = httpContext;
            _thread = thread;
        }

        public IEnumerable<Theme> All()
        {
            var retval = new List<Theme>();

            var themesPath = _httpContext.Current.Server.MapPath("~/css/");
            var themes = _fileSystem.Directory.GetDirectories(themesPath);

            foreach (var theme in themes)
            {
                var id = theme.Substring(theme.LastIndexOf("\\", StringComparison.Ordinal) + 1);

                var name = _thread.CurrentCulture.TextInfo
                    .ToTitleCase(id.Replace("-", " "))
                    .Replace("Agebase", "AgeBase");

                retval.Add(new Theme
                {
                    Id = id,
                    Name = name
                });
            }

            return retval;
        }
    }
}