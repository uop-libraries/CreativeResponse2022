using DTT.InfiniteScroll.Util;
using UnityEditor;
using UnityEngine.UI;

namespace DTT.InfiniteScroll.Editor
{
    /// <summary>
    /// Contains the menu options for <see cref="InfiniteScroll"/>.
    /// </summary>
    internal class InfiniteScrollMenu
    {
        /// <summary>
        /// Creates the infinite scroll from the create menu.
        /// </summary>
        [MenuItem("GameObject/UI/Infinite Scroll")]
        public static void CreateInfiniteScroll()
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Scroll View");
            ScrollRect scrollRect = Selection.activeGameObject.GetComponent<ScrollRect>();
            if (scrollRect == null)
                return;
            InfiniteScroll infiniteScroll = scrollRect.ToInfiniteScroll();
            infiniteScroll.gameObject.name = "Infinite Scroll";
        }
    }
}