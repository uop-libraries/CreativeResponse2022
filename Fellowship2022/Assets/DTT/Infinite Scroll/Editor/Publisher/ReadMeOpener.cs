#if UNITY_EDITOR

using DTT.PublishingTools;
using UnityEditor;

namespace DTT.InfiniteScroll.Editor
{
    /// <summary>
    /// Class that handles opening the editor window for the Infinite Scroll package.
    /// </summary>
    internal static class ReadMeOpener
    {
        /// <summary>
        /// Opens the readme for this package.
        /// </summary>
        [MenuItem("Tools/DTT/Infinite Scroll/ReadMe")]
        private static void OpenReadMe() => DTTEditorConfig.OpenReadMe("dtt.infinite-scroll");
    }
}
#endif