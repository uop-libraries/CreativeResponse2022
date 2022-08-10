using DTT.Utils.Extensions;
using UnityEngine;

namespace DTT.InfiniteScroll.Util
{
    /// <summary>
    /// Defines extension methods for <see cref="RectTransform"/> class.
    /// </summary>
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Retrieves the first child of the recttransform. Or null if there are no children.
        /// </summary>
        /// <param name="transform">The recttransform to retrieve the first child from.</param>
        /// <returns>The first child or null if there are no children.</returns>
        public static RectTransform GetFirstChild(this RectTransform transform) 
            => transform.childCount > 0 ? transform.GetChild(0).GetRectTransform() : null;
        
        /// <summary>
        /// Retrieves the last child of the recttransform. Or null if there are no children..
        /// </summary>
        /// <param name="transform">The recttransform to retrieve the last child from.</param>
        /// <returns>The last child or null if there are no children.</returns>
        public static RectTransform GetLastChild(this RectTransform transform) 
            => transform.childCount > 0 ? transform.GetChild(transform.childCount - 1).GetRectTransform() : null;
    }
}