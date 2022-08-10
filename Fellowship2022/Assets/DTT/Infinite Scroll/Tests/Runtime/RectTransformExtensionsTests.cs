using DTT.InfiniteScroll.Util;
using DTT.Utils.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace DTT.InfiniteScroll.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="DTT.InfiniteScroll.Util.RectTransformExtensions"/> class.
    /// </summary>
    public class RectTransformExtensionsTests
    {
        /// <summary>
        /// Tests the getting of the first child being the correct one.
        /// Expects the first child to be the first instantiated gameobject in the parent.
        /// </summary>
        [Test]
        public void GetFirstChild_IsIndeedFirstChild()
        {
            GameObject go = new GameObject("Parent");
            RectTransform child1 = new GameObject("Child 1").AddComponent<RectTransform>();
            RectTransform child2 = new GameObject("Child 2").AddComponent<RectTransform>();
            child1.SetParent(go.transform);
            child2.SetParent(go.transform);
            
            RectTransform firstChild = go.AddComponent<RectTransform>().GetFirstChild();
            
            Assert.AreEqual(child1, firstChild);
            Object.Destroy(go);
        }
        
        /// <summary>
        /// Tests the getting of the last child being the correct one.
        /// Expects the last child to be the last instantiated gameobject in the parent.
        /// </summary>
        [Test]
        public void GetLastChild_IsIndeedLastChild()
        {
            GameObject go = new GameObject("Parent");
            RectTransform child1 = new GameObject("Child 1").AddComponent<RectTransform>();
            RectTransform child2 = new GameObject("Child 2").AddComponent<RectTransform>();
            child1.SetParent(go.transform);
            child2.SetParent(go.transform);
            
            RectTransform lastChild = go.AddComponent<RectTransform>().GetLastChild();
            
            Assert.AreEqual(child2, lastChild);
            Object.Destroy(go);
        }
        
        /// <summary>
        /// Tests whether the correct return value is given when the parent has no children.
        /// Expects to return null.
        /// </summary>
        [Test]
        public void GetFirstChild_WithNoChildren_ReturnsNull()
        {
            GameObject go = new GameObject("Parent");

            RectTransform child = go.AddComponent<RectTransform>().GetFirstChild();
            
            Assert.IsNull(child);
            Object.Destroy(go);
        }
        
        /// <summary>
        /// Tests whether the correct return value is given when the parent has no children.
        /// Expects to return null.
        /// </summary>
        [Test]
        public void GetLastChild_WithNoChildren_ReturnsNull()
        {
            GameObject go = new GameObject("Parent");

            RectTransform child = go.AddComponent<RectTransform>().GetLastChild();
            
            Assert.IsNull(child);
            Object.Destroy(go);
        }
    }
}