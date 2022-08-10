using System;

namespace DTT.InfiniteScroll.Util
{
    /// <summary>
    /// Utility methods that are used in the Infinite Scroll package.
    /// </summary>
    public static class InfiniteScrollUtils
    {
        /// <summary>
        /// Retries an action until the predicate evaluates successfully.
        /// </summary>
        /// <param name="predicate">The predicate to poll for success.</param>
        /// <param name="action">The action perform until the predicate is evaluated truthfully.</param>
        public static void RetryUntil(Func<bool> predicate, Action action)
        {
            while (predicate())
                action?.Invoke();
        }
    }
}