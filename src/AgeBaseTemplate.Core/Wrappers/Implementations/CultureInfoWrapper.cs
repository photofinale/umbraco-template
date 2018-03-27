using System.Globalization;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class CultureInfoWrapper : ICultureInfo
    {
        private readonly IThread _thread;

        public CultureInfoWrapper(IThread thread)
        {
            _thread = thread;
        }

        public CultureInfo CurrentCulture => _thread.CurrentThread.CurrentCulture;
    }
}