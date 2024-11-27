using System.Threading;
using System.Threading.Tasks;

namespace Org.BouncyCastle
{
#if NETSTANDARD2_1_OR_GREATER
    internal class ValueTaskExtension
    {
        public static ValueTask FromCanceled(CancellationToken cancellationToken)
        {
            return new ValueTask(Task.FromCanceled(cancellationToken));
        }

        public static ValueTask CompletedTask()
        {
            return new ValueTask(Task.CompletedTask);
        }
    }
#endif
}
