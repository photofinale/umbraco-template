using System.Globalization;
using System.Threading;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class CultureInfoWrapper : ICultureInfo
    {
        public CultureInfo CurrentCulture => Thread.CurrentThread.CurrentCulture;
    }
}