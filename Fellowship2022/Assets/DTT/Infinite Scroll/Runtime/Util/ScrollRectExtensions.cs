using System;
using DTT.InfiniteScroll;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DTT.InfiniteScroll.Util
{
    /// <summary>
    /// Defines extension methods for <see cref="ScrollRect"/> class.
    /// </summary>
    public static class ScrollRectExtensions
    {
        /// <summary>
        /// Upgrades a <see cref="ScrollRect"/> to a <see cref="InfiniteScroll"/> by removing and adding the components and transferring state.
        /// </summary>
        /// <param name="scrollRect">The scroll rect to update to an infinite scroll.</param>
        /// <returns>The newly created infinite scroll.</returns>
        /// <exception cref="ArgumentNullException">Thrown if argument null.</exception>
        public static InfiniteScroll ToInfiniteScroll(this ScrollRect scrollRect)
        {
            if (scrollRect == null) throw new ArgumentNullException(nameof(scrollRect));
            
            // Save reference to attached GameObject.
            GameObject gameObject = scrollRect.gameObject;
            
            // Save settings of the scroll rect, since we can't access these when the component is destroyed.
            var scrollRectSettings = new
            {
                scrollRect.content,
                scrollRect.horizontal,
                scrollRect.vertical,
                scrollRect.inertia,
                scrollRect.decelerationRate,
                scrollRect.scrollSensitivity,
                scrollRect.viewport,
                scrollRect.onValueChanged
            };
            
            // Destroy objects.
            scrollRect.viewport.sizeDelta = Vector2.zero;
            if(scrollRect.horizontalScrollbar != null)
                Object.DestroyImmediate(scrollRect.horizontalScrollbar.gameObject);
            if(scrollRect.verticalScrollbar != null)
                Object.DestroyImmediate(scrollRect.verticalScrollbar.gameObject);
            
            Object.DestroyImmediate(scrollRect);
            
            // Add the new scroll rect.
            InfiniteScroll infiniteScroll = gameObject.AddComponent<InfiniteScroll>();
            
            // Apply settings from previous scroll rect.
            infiniteScroll.content = scrollRectSettings.content;
            infiniteScroll.horizontal = scrollRect.horizontal;
            infiniteScroll.vertical = scrollRect.vertical;
            infiniteScroll.inertia = scrollRect.inertia;
            infiniteScroll.decelerationRate = scrollRect.decelerationRate;
            infiniteScroll.scrollSensitivity = scrollRect.scrollSensitivity;
            infiniteScroll.viewport = scrollRect.viewport;
            infiniteScroll.onValueChanged = scrollRect.onValueChanged;

            return infiniteScroll;
        }
    }
}