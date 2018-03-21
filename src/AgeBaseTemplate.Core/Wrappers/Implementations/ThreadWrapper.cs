using System.Globalization;
using System.Threading;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class ThreadWrapper : IThread
    {
        public Thread Current => Thread.CurrentThread;

        public CultureInfo CurrentCulture => Thread.CurrentThread.CurrentCulture;
    }
}