using System.Globalization;
using System.Threading;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface IThread
    {
        Thread Current { get; }

        CultureInfo CurrentCulture { get; }
    }
}