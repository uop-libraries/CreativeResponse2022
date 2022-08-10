using DTT.InfiniteScroll.Util;
using UnityEditor;
using UnityEngine.UI;

namespace DTT.InfiniteScroll.Editor
{
    /// <summary>
    /// Contains the menu options for <see cref="ScrollRect"/>.
    /// </summary>
    internal static class ScrollRectMenu
    {
        /// <summary>
        /// Adds the context menu option to <see cref="ScrollRect"/> to upgrade it to a <see cref="InfiniteScroll"/>.
        /// </summary>
        /// <param name="command">The command options from the context event.</param>
        [MenuItem("CONTEXT/ScrollRect/Upgrade to Infinite Scroll")]
        private static void ScrollRectToInfiniteScroll(MenuCommand command)
        {
            ScrollRect scrollRect = command.context as ScrollRect;
            if (scrollRect == null)
                return;
            scrollRect.ToInfiniteScroll();
        }
    }
}