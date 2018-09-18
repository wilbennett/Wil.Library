using System.Threading;

namespace Wil.Core
{
    public static class SemaphoreUtils
    {
        public static void ReleaseMax(this SemaphoreSlim instance, int maxCount)
        {
            if (instance.CurrentCount < maxCount)
                instance.Release(maxCount - instance.CurrentCount);
        }
    }
}