using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DTT.InfiniteScroll.Util
{
    /// <summary>
    /// Defines the layout group items for <see cref="LayoutGroup"/> class.
    /// </summary>
    internal static class LayoutGroupMenuItems
    {
        /// <summary>
        /// Adds an option to <see cref="VerticalLayoutGroup"/> component menu to switch it to a <see cref="HorizontalLayoutGroup"/>.
        /// </summary>
        /// <param name="command">The command options passed from the menu.</param>
        [MenuItem("CONTEXT/VerticalLayoutGroup/Switch to Horizontal Layout Group")]
        private static void SwitchVerticalLayoutGroupToHorizontalLayoutGroupMenu(MenuCommand command)
        {
            VerticalLayoutGroup verticalLayoutGroup = command.context as VerticalLayoutGroup;
            if (verticalLayoutGroup == null)
                return;
            verticalLayoutGroup.SwitchToHorizontalLayoutGroup();
        }
        
        /// <summary>
        /// Adds an option to <see cref="HorizontalLayoutGroup"/> component menu to switch it to a <see cref="VerticalLayoutGroup"/>.
        /// </summary>
        /// <param name="command">The command options passed from the menu.</param>
        [MenuItem("CONTEXT/HorizontalLayoutGroup/Switch to Vertical Layout Group")]
        private static void SwitchHorizontalLayoutGroupToVerticalLayoutGroupMenu(MenuCommand command)
        {
            HorizontalLayoutGroup horizontalLayoutGroup = command.context as HorizontalLayoutGroup;
            if (horizontalLayoutGroup == null)
                return;
            horizontalLayoutGroup.SwitchToVerticalLayoutGroup();
        }
    }
}