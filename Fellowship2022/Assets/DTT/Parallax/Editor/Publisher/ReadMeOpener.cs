#if UNITY_EDITOR

using DTT.PublishingTools;
using UnityEditor;

namespace DTT.Parallax.Editor
{
    /// <summary>
    /// Class that handles opening the editor window for the parallax package.
    /// </summary>
    internal static class ReadMeOpener
    {
        /// <summary>
        /// Opens the readme for this package.
        /// </summary>
        [MenuItem("Tools/DTT/Parallax/ReadMe")]
        private static void OpenReadMe() => DTTEditorConfig.OpenReadMe("dtt.parallax");
    }
}
#endif