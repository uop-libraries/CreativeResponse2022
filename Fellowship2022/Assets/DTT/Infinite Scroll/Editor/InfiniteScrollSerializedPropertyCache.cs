using DTT.Utils.EditorUtilities;
using UnityEditor;

namespace DTT.InfiniteScroll.Editor
{
    /// <summary>
    /// Contains all the serialized properties for the <see cref="InfiniteScroll"/> class.
    /// </summary>
    internal class InfiniteScrollSerializedPropertyCache : SerializedPropertyCache
    {
        /// <summary>
        /// Serialized property for the content property.
        /// </summary>
        public SerializedProperty ContentProperty => base["m_Content"];
        
        /// <summary>
        /// Serialized property for the horizontal property.
        /// </summary>
        public SerializedProperty HorizontalProperty => base["m_Horizontal"];
        
        /// <summary>
        /// Serialized property for the vertical property.
        /// </summary>
        public SerializedProperty VerticalProperty => base["m_Vertical"];
        
        /// <summary>
        /// Serialized property for the movement type property.
        /// </summary>
        public SerializedProperty MovementTypeProperty => base["m_MovementType"];
        
        /// <summary>
        /// Serialized property for the elasticity property.
        /// </summary>
        public SerializedProperty ElasticityProperty => base["m_Elasticity"];
        
        /// <summary>
        /// Serialized property for the inertia property.
        /// </summary>
        public SerializedProperty InertiaProperty => base["m_Inertia"];
        
        /// <summary>
        /// Serialized property for the deceleration rate property.
        /// </summary>
        public SerializedProperty DecelerationRateProperty => base["m_DecelerationRate"];
        
        /// <summary>
        /// Serialized property for the scroll sensitivity property.
        /// </summary>
        public SerializedProperty ScrollSensitivity => base["m_ScrollSensitivity"];
        
        /// <summary>
        /// Serialized property for the viewport property.
        /// </summary>
        public SerializedProperty ViewportProperty => base["m_Viewport"];
        
        /// <summary>
        /// Serialized property for the horizontal scroll property.
        /// </summary>
        public SerializedProperty HorizontalScrollbarProperty => base["m_HorizontalScrollbar"];
        
        /// <summary>
        /// Serialized property for the vertical scroll property.
        /// </summary>
        public SerializedProperty VerticalScrollbarProperty => base["m_VerticalScrollbar"];
        
        /// <summary>
        /// Serialized property for the horizontal scrollbar visibility property.
        /// </summary>
        public SerializedProperty HorizontalScrollbarVisibilityProperty => base["m_HorizontalScrollbarVisibility"];
        
        /// <summary>
        /// Serialized property for the vertical scrollbar visibility property.
        /// </summary>
        public SerializedProperty VerticalScrollbarVisibilityProperty => base["m_VerticalScrollbarVisibility"];
        
        /// <summary>
        /// Serialized property for the horizontal scrollbar spacing property.
        /// </summary>
        public SerializedProperty HorizontalScrollbarSpacingProperty => base["m_HorizontalScrollbarSpacing"];
        
        /// <summary>
        /// Serialized property for the vertical scrollbar spacing property.
        /// </summary>
        public SerializedProperty VerticalScrollbarSpacingProperty => base["m_VerticalScrollbarSpacing"];
        
        /// <summary>
        /// Serialized property for the on value changed property.
        /// </summary>
        public SerializedProperty OnValueChangedProperty => base["m_OnValueChanged"];
        
        /// <summary>
        /// Explicit constructor to call base.
        /// </summary>
        /// <param name="serializedObject">The object to gain the serialized properties from.</param>
        public InfiniteScrollSerializedPropertyCache(SerializedObject serializedObject) : base(serializedObject) {}
    }
}