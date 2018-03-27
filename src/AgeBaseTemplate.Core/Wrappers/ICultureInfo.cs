using System.Globalization;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface ICultureInfo
    {
        CultureInfo CurrentCulture { get; }
    }
}