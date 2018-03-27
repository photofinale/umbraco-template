using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using AgeBaseTemplate.Core.Models;
using AgeBaseTemplate.Core.Wrappers;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class ThemeService : IThemeService
    {
        private readonly ICultureInfo _cultureInfo;
        private readonly IFileSystem _fileSystem;
        private readonly IHttpServerUtility _httpServerUtility;
        private readonly IProfileLogger _profileLogger;

        public ThemeService(
            ICultureInfo cultureInfo,
            IFileSystem fileSystem,
            IHttpServerUtility httpServerUtility, 
            IProfileLogger profileLogger)
        {
            _cultureInfo = cultureInfo;
            _fileSystem = fileSystem;
            _httpServerUtility = httpServerUtility;
            _profileLogger = profileLogger;
        }

        public IEnumerable<Theme> All()
        {
            using (_profileLogger.TraceDuration<ThemeService>("All"))
            {
                var retval = new List<Theme>();

                var themesPath = _httpServerUtility.MapPath("~/css/");
                var themes = _fileSystem.Directory.GetDirectories(themesPath);

                foreach (var theme in themes)
                {
                    var id = theme.TrimEnd('\\');
                    id = id.Substring(id.LastIndexOf("\\", StringComparison.Ordinal) + 1);

                    var name = _cultureInfo.CurrentCulture.TextInfo
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
}