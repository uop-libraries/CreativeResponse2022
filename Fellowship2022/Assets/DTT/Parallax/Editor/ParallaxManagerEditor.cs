using DTT.PublishingTools;
using UnityEditor;

namespace DTT.Parallax.Editor
{
    /// <summary>
    /// The custom editor for the <see cref="ParallaxManager"/> class.
    /// </summary>
    [CustomEditor(typeof(ParallaxManager))]
    [CanEditMultipleObjects]
    [DTTHeader("dtt.parallax", "Parallax Manager")]
    internal class ParallaxManagerEditor : DTTInspector
    {
        /// <summary>
        /// The toggled value of the automatic multipliers.
        /// </summary>
        private SerializedProperty _multipliersToggle;

        /// <summary>
        /// The layers for the parallax.
        /// </summary>
        private SerializedProperty _layers;

        /// <summary>
        /// Caches the value of the multipliers toggle property.
        /// </summary>
        protected override void OnEnable()
        {
            _multipliersToggle = serializedObject.FindProperty("_setMultipliersAutomatically");
            _layers = serializedObject.FindProperty("_layers");
            base.OnEnable();
        }

        /// <summary>
        /// Draws the inspector.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            DrawPropertiesExcluding(serializedObject, "m_Script", "_setMultipliersAutomatically", "_layers");

            // Checks whether or not the automatic multiplier variable should be set to true.
            if (_multipliersToggle.boolValue)
                EditorGUILayout.HelpBox("This will override the Parallax Multiplier value of the layers based on the order of the list", MessageType.Warning);

            EditorGUILayout.PropertyField(_multipliersToggle);
            EditorGUILayout.PropertyField(_layers) ;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
