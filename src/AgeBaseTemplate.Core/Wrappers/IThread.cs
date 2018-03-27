using System.Threading;

namespace AgeBaseTemplate.Core.Wrappers
{
    public interface IThread
    {
        Thread CurrentThread { get; }
    }
}