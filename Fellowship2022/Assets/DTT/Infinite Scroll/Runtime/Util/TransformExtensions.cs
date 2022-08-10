using UnityEngine;

namespace DTT.InfiniteScroll.Util
{
    /// <summary>
    /// Contains extension methods for the <see cref="Transform"/> class.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Retrieves the first child of the transform. Or null if there are no children.
        /// </summary>
        /// <param name="transform">The transform to retrieve the first child from.</param>
        /// <returns>The first child or null if there are no children.</returns>
        public static Transform GetFirstChild(this Transform transform) 
            => transform.childCount > 0 ? transform.GetChild(0) : null;
        
        /// <summary>
        /// Retrieves the last child of the transform. Or null if there are no children..
        /// </summary>
        /// <param name="transform">The transform to retrieve the last child from.</param>
        /// <returns>The last child or null if there are no children.</returns>
        public static Transform GetLastChild(this Transform transform) 
            => transform.childCount > 0 ? transform.GetChild(transform.childCount - 1) : null;
    }
}