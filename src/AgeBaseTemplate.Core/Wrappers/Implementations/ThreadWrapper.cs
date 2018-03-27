using System.Threading;

namespace AgeBaseTemplate.Core.Wrappers.Implementations
{
    public class ThreadWrapper : IThread
    {
        public Thread CurrentThread => Thread.CurrentThread;
    }
}