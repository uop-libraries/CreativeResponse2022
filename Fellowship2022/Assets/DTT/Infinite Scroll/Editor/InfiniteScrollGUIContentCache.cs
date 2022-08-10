using DTT.Utils.EditorUtilities;
using UnityEngine;

namespace DTT.InfiniteScroll.Editor
{
    /// <summary>
    /// All the required GUI content for the <see cref="InfiniteScroll"/> class.
    /// </summary>
    internal class InfiniteScrollGUIContentCache : GUIContentCache
    {
        /// <summary>
        /// GUI content for the content reference.
        /// </summary>
        public GUIContent ContentContent => base[nameof(ContentContent)];
        
        /// <summary>
        /// GUI content for the horizontal toggle.
        /// </summary>
        public GUIContent HorizontalContent => base[nameof(HorizontalContent)];
        
        /// <summary>
        /// GUI content for the vertical toggle.
        /// </summary>
        public GUIContent VerticalContent => base[nameof(VerticalContent)];
        
        /// <summary>
        /// GUI content for the inertia toggle.
        /// </summary>
        public GUIContent InertiaContent => base[nameof(InertiaContent)];
        
        /// <summary>
        /// GUI content for the deceleration rate field.
        /// </summary>
        public GUIContent DecelerationRateContent => base[nameof(DecelerationRateContent)];
        
        /// <summary>
        /// GUI content for the scroll sensitivity field.
        /// </summary>
        public GUIContent ScrollSensitivityContent => base[nameof(ScrollSensitivityContent)];
        
        /// <summary>
        /// GUI content for the viewport reference.
        /// </summary>
        public GUIContent ViewportContent => base[nameof(ViewportContent)];
        
        /// <summary>
        /// GUI content for the on value changed event.
        /// </summary>
        public GUIContent OnValueChangedContent => base[nameof(OnValueChangedContent)];
        
        /// <summary>
        /// Constructs and caches all the GUI content.
        /// </summary>
        public InfiniteScrollGUIContentCache()
        {
            Add(nameof(ContentContent),           () => new GUIContent("Content",            "The content that can be scrolled. It should be a child of the GameObject with ScrollRect on it."));
            Add(nameof(HorizontalContent),        () => new GUIContent("Horizontal",         "Should horizontal scrolling be enabled?"));
            Add(nameof(VerticalContent),          () => new GUIContent("Vertical",           "Should vertical scrolling be enabled?"));
            Add(nameof(InertiaContent),           () => new GUIContent("Inertia",            "Should movement inertia be enabled?"));
            Add(nameof(DecelerationRateContent),  () => new GUIContent("Deceleration Rate",  "The rate at which movement slows down."));
            Add(nameof(ScrollSensitivityContent), () => new GUIContent("Scroll Sensitivity", "The sensitivity to scroll wheel and track pad scroll events."));
            Add(nameof(ViewportContent),          () => new GUIContent("Viewport",           "Reference to the viewport RectTransform that is the parent of the content RectTransform."));
            Add(nameof(OnValueChangedContent),    () => new GUIContent("On Value Changed",   "Callback executed when the position of the child changes."));
        }
    }
}