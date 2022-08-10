using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DTT.InfiniteScroll.Util
{
    /// <summary>
    /// Defines extension methods for <see cref="LayoutGroup"/> classes.
    /// </summary>
    public static class LayoutGroupExtensions
    {
        /// <summary>
        /// Switches the passed <see cref="VerticalLayoutGroup"/> component out with a <see cref="HorizontalLayoutGroup"/> component and returns that.
        /// This deletes the component passed and adds the new component to the same GameObject.
        /// </summary>
        /// <param name="verticalLayoutGroup">The <see cref="VerticalLayoutGroup"/> to switch out.</param>
        /// <returns>The newly added <see cref="HorizontalLayoutGroup"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if argument null.</exception>
        public static HorizontalLayoutGroup SwitchToHorizontalLayoutGroup(this VerticalLayoutGroup verticalLayoutGroup)
        {
            if (verticalLayoutGroup == null) throw new ArgumentNullException(nameof(verticalLayoutGroup));
            
            // Save reference to attached GameObject.
            GameObject gameObject = verticalLayoutGroup.gameObject;
            
            // Save settings of the layout, since we can't access these when the component is destroyed.
            // Uses anonymous type definition to bind the variables in a single type.
            var vGroupSettings = new
            {
                verticalLayoutGroup.spacing,
                verticalLayoutGroup.padding,
                verticalLayoutGroup.childAlignment,
                verticalLayoutGroup.childControlHeight,
                verticalLayoutGroup.childControlWidth,
                verticalLayoutGroup.childScaleHeight,
                verticalLayoutGroup.childScaleWidth,
                verticalLayoutGroup.childForceExpandHeight,
                verticalLayoutGroup.childForceExpandWidth,
                #if UNITY_2020_OR_HIGHER
                verticalLayoutGroup.reverseArrangement
                #endif
            };
            
            // Destroy object.
            Object.DestroyImmediate(verticalLayoutGroup);
            
            // Add the new layout group.
            HorizontalLayoutGroup horizontalLayoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>();
            
            // Apply settings from previous layout group.
            horizontalLayoutGroup.spacing = vGroupSettings.spacing;
            horizontalLayoutGroup.padding = vGroupSettings.padding;
            horizontalLayoutGroup.childAlignment = vGroupSettings.childAlignment;
            horizontalLayoutGroup.childControlHeight = vGroupSettings.childControlHeight;
            horizontalLayoutGroup.childControlWidth = vGroupSettings.childControlWidth;
            horizontalLayoutGroup.childScaleHeight = vGroupSettings.childScaleHeight;
            horizontalLayoutGroup.childScaleWidth = vGroupSettings.childScaleWidth;
            horizontalLayoutGroup.childForceExpandHeight = vGroupSettings.childForceExpandHeight;
            horizontalLayoutGroup.childForceExpandWidth = vGroupSettings.childForceExpandWidth;
            #if UNITY_2020_OR_HIGHER
            horizontalLayoutGroup.reverseArrangement = vGroupSettings.reverseArrangement;
            #endif

            // Return the new layout.
            return horizontalLayoutGroup;
        }
        
        /// <summary>
        /// Switches the passed <see cref="HorizontalLayoutGroup"/> component out with a <see cref="VerticalLayoutGroup"/> component and returns that.
        /// This deletes the component passed and adds the new component to the same GameObject.
        /// </summary>
        /// <param name="horizontalLayoutGroup">The <see cref="HorizontalLayoutGroup"/> to switch out.</param>
        /// <returns>The newly added <see cref="VerticalLayoutGroup"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if argument null.</exception>
        public static VerticalLayoutGroup SwitchToVerticalLayoutGroup(this HorizontalLayoutGroup horizontalLayoutGroup)
        {
            if (horizontalLayoutGroup == null) throw new ArgumentNullException(nameof(horizontalLayoutGroup));
            
            // Save reference to attached GameObject.
            GameObject gameObject = horizontalLayoutGroup.gameObject;
            
            // Save settings of the layout, since we can't access these when the component is destroyed.
            // Uses anonymous type definition to bind the variables in a single type.
            var hGroupSettings = new
            {
                horizontalLayoutGroup.spacing,
                horizontalLayoutGroup.padding,
                horizontalLayoutGroup.childAlignment,
                horizontalLayoutGroup.childControlHeight,
                horizontalLayoutGroup.childControlWidth,
                horizontalLayoutGroup.childScaleHeight,
                horizontalLayoutGroup.childScaleWidth,
                horizontalLayoutGroup.childForceExpandHeight,
                horizontalLayoutGroup.childForceExpandWidth,
                #if UNITY_2020_OR_HIGHER
                horizontalLayoutGroup.reverseArrangement
                #endif
            };
            
            // Destroy object.
            Object.DestroyImmediate(horizontalLayoutGroup);
            
            // Add the new layout group.
            VerticalLayoutGroup verticalLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();
            
            // Apply settings from previous layout group.
            verticalLayoutGroup.spacing = hGroupSettings.spacing;
            verticalLayoutGroup.padding = hGroupSettings.padding;
            verticalLayoutGroup.childAlignment = hGroupSettings.childAlignment;
            verticalLayoutGroup.childControlHeight = hGroupSettings.childControlHeight;
            verticalLayoutGroup.childControlWidth = hGroupSettings.childControlWidth;
            verticalLayoutGroup.childScaleHeight = hGroupSettings.childScaleHeight;
            verticalLayoutGroup.childScaleWidth = hGroupSettings.childScaleWidth;
            verticalLayoutGroup.childForceExpandHeight = hGroupSettings.childForceExpandHeight;
            verticalLayoutGroup.childForceExpandWidth = hGroupSettings.childForceExpandWidth;
            #if UNITY_2020_OR_HIGHER
            verticalLayoutGroup.reverseArrangement = hGroupSettings.reverseArrangement;
            #endif

            return verticalLayoutGroup;
        }
        
        /// <summary>
        /// Switches the given <see cref="HorizontalOrVerticalLayoutGroup"/> out based on the subtype.
        /// </summary>
        /// <param name="horizontalOrVerticalLayoutGroup">The group to be switched out.</param>
        /// <returns>The switched layout group.</returns>
        public static HorizontalOrVerticalLayoutGroup SwitchBetweenHorizontalAndVerticalLayoutGroup(this HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup)
        {
            if (horizontalOrVerticalLayoutGroup is HorizontalLayoutGroup horizontalLayoutGroup)
                return horizontalLayoutGroup.SwitchToVerticalLayoutGroup();
            if (horizontalOrVerticalLayoutGroup is VerticalLayoutGroup verticalLayoutGroup)
                return verticalLayoutGroup.SwitchToHorizontalLayoutGroup();
            
            throw new NotSupportedException("The SwitchBetweenHorizontalAndVerticalLayoutGroup method only works with Horizontal and Vertical layout groups.");
        }
    }
}