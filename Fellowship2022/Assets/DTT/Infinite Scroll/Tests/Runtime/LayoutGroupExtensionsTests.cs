using System.Collections;
using DTT.InfiniteScroll.Util;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace DTT.InfiniteScroll.Tests
{
    /// <summary>
    /// Contains the unit tests for the <see cref="LayoutGroupExtensions"/> class.
    /// </summary>
    public class LayoutGroupExtensionsTest
    {
        /// <summary>
        /// Tests the switching of a <see cref="HorizontalLayoutGroup"/> to a <see cref="VerticalLayoutGroup"/>.
        /// Expects the <see cref="HorizontalLayoutGroup"/> to be removed and to have the <see cref="VerticalLayoutGroup"/> component.
        /// </summary>
        [UnityTest]
        public IEnumerator SwitchHorizontalToVertical_DestroysAndAddsCorrectComponent()
        {
            GameObject go = new GameObject("Layout");
            HorizontalLayoutGroup horizontalLayoutGroup = go.AddComponent<HorizontalLayoutGroup>();

            yield return null;

            var vGroup = horizontalLayoutGroup.SwitchToVerticalLayoutGroup();
            
            Assert.AreEqual(vGroup, go.GetComponent<VerticalLayoutGroup>());
            Object.Destroy(go);
        }
        
        /// <summary>
        /// Tests the switching of a <see cref="VerticalLayoutGroup"/> to a <see cref="HorizontalLayoutGroup"/>.
        /// Expects the <see cref="VerticalLayoutGroup"/> to be removed and to have the <see cref="HorizontalLayoutGroup"/> component.
        /// </summary>
        [UnityTest]
        public IEnumerator SwitchVerticalToHorizontal_DestroysAndAddsCorrectComponent()
        {
            GameObject go = new GameObject("Layout");
            VerticalLayoutGroup horizontalLayoutGroup = go.AddComponent<VerticalLayoutGroup>();

            yield return null;

            var hGroup = horizontalLayoutGroup.SwitchToHorizontalLayoutGroup();
            
            Assert.AreEqual(hGroup, go.GetComponent<HorizontalLayoutGroup>());
            Object.Destroy(go);
        }
        
        /// <summary>
        /// Tests the switching of a generic <see cref="HorizontalOrVerticalLayoutGroup"/> to a <see cref="VerticalLayoutGroup"/>.
        /// Expects the <see cref="HorizontalLayoutGroup"/> to be removed and to have the <see cref="VerticalLayoutGroup"/> component.
        /// </summary>
        [UnityTest]
        public IEnumerator SwitchBetweenHorizontalAndVerticalLayoutGroup_HorizontalToVertical_DestroysAndAddsCorrectComponent()
        {
            GameObject go = new GameObject("Layout");
            HorizontalOrVerticalLayoutGroup group = go.AddComponent<HorizontalLayoutGroup>();

            yield return null;

            group = group.SwitchBetweenHorizontalAndVerticalLayoutGroup();
            
            Assert.AreEqual(group, go.GetComponent<VerticalLayoutGroup>());
            Object.Destroy(go);
        }
        
        /// <summary>
        /// Tests the switching of a generic <see cref="HorizontalOrVerticalLayoutGroup"/> to a <see cref="HorizontalLayoutGroup"/>.
        /// Expects the <see cref="VerticalLayoutGroup"/> to be removed and to have the <see cref="HorizontalLayoutGroup"/> component.
        /// </summary>
        [UnityTest]
        public IEnumerator SwitchBetweenHorizontalAndVerticalLayoutGroup_VerticalToHorizontal_DestroysAndAddsCorrectComponent()
        {
            GameObject go = new GameObject("Layout");
            HorizontalOrVerticalLayoutGroup group = go.AddComponent<VerticalLayoutGroup>();

            yield return null;

            group = group.SwitchBetweenHorizontalAndVerticalLayoutGroup();
            
            Assert.AreEqual(group, go.GetComponent<HorizontalLayoutGroup>());
            Object.Destroy(go);
        }
    }
}