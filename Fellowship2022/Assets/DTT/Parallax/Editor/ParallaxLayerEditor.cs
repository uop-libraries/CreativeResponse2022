using DTT.PublishingTools;
using UnityEditor;

namespace DTT.Parallax.Editor
{
    /// <summary>
    /// The custom editor for the <see cref="ParallaxLayer"/> class.
    /// </summary>
    [CustomEditor(typeof(ParallaxLayer))]
    [CanEditMultipleObjects]
    [DTTHeader("dtt.parallax", "Parallax Layer")]
    internal class ParallaxLayerEditor : DTTInspector
    {
        /// <summary>
        /// Draws the inspector.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawDefaultInspector();
        }
    }
}
