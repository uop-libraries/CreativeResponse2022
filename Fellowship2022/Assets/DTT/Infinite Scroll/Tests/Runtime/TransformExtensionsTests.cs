using DTT.InfiniteScroll.Util;
using NUnit.Framework;
using UnityEngine;

namespace DTT.InfiniteScroll.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="DTT.InfiniteScroll.Util.TransformExtensions"/> class.
    /// </summary>
    public class TransformExtensionsTests
    {
        /// <summary>
        /// Tests the getting of the first child being the correct one.
        /// Expects the first child to be the first instantiated gameobject in the parent.
        /// </summary>
        [Test]
        public void GetFirstChild_IsIndeedFirstChild()
        {
            GameObject go = new GameObject("Parent");
            Transform child1 = new GameObject("Child 1").transform;
            Transform child2 = new GameObject("Child 2").transform;
            child1.SetParent(go.transform);
            child2.SetParent(go.transform);
            
            Transform firstChild = go.transform.GetFirstChild();
            
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
            Transform child1 = new GameObject("Child 1").transform;
            Transform child2 = new GameObject("Child 2").transform;
            child1.transform.SetParent(go.transform);
            child2.transform.SetParent(go.transform);
            
            Transform lastChild = go.transform.GetLastChild();
            
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

            Transform child = go.transform.GetFirstChild();
            
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

            Transform child = go.transform.GetLastChild();
            
            Assert.IsNull(child);
            Object.Destroy(go);
        }
    }
}