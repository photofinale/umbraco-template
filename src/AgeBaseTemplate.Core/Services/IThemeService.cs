using System.Collections.Generic;
using AgeBaseTemplate.Core.Models;

namespace AgeBaseTemplate.Core.Services
{
    public interface IThemeService
    {
        IEnumerable<Theme> All();
    }
}