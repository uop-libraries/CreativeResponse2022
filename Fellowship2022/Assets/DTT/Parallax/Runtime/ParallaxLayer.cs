using System;
using UnityEngine;

namespace DTT.Parallax
{
    /// <summary>
    /// Class that handles a parallax layer.
    /// </summary>
    public class ParallaxLayer : MonoBehaviour
    {
        /// <summary>
        /// The type of display the parallax layer should have. 0 is none.
        /// </summary>
        [Flags]
        public enum ParallaxDisplay
        {
            /// <summary>
            /// Used to display the dynamic background horizontally.
            /// </summary>
            [InspectorName("Horizontal")]
            HORIZONTAL = 1,

            /// <summary>
            /// Used to display the dynamic background vertically.
            /// </summary>
            [InspectorName("Vertical")]
            VERTICAL = 2,
        }

        /// <summary>
        /// The type of display chosen for the layer.
        /// </summary>
        [SerializeField]
        [Tooltip("The type of display chosen for the layer.")]
        private ParallaxDisplay _displayType;

        /// <summary>
        /// The speed at which the layer moves relative to the target, the higher the faster.
        /// </summary>
        [SerializeField]
        [Range(0, 1)]
        [Tooltip("The speed at which the layer moves relative to the target, the higher the faster")]
        private float _parallaxMultiplier;

        /// <summary>
        /// Whether the parallax effect on the layer should display horizontally.
        /// </summary>
        public bool HorizontalParallax => _displayType.HasFlag(ParallaxDisplay.HORIZONTAL);

        /// <summary>
        /// Whether the parallax effect on the layer should display vertically.
        /// </summary>
        public bool VerticalParallax => _displayType.HasFlag(ParallaxDisplay.VERTICAL);

        /// <summary>
        /// The speed at which the layer moves relative to the target, the higher the faster.
        /// </summary>
        public float ParallaxMultiplier => _parallaxMultiplier;

        /// <summary>
        /// The width and height of the texture.
        /// </summary>
        private Vector2 _textureSize;

        /// <summary>
        /// The start position of the layer.
        /// </summary>
        private Vector2 _startPos;

        /// <summary>
        /// The SpriteRenderer for the current parallax layer;
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// Caches the SpriteRenderer component of the object.
        /// </summary>
        private void Awake() => _spriteRenderer = this.GetComponent<SpriteRenderer>();

        /// <summary>
        /// Sets the size measurements for the layer and saves the starting position.
        /// </summary>
        private void Start()
        {
            float textureWidth = (_spriteRenderer.sprite.texture.width / _spriteRenderer.sprite.pixelsPerUnit) * this.transform.localScale.x; 
            float textureHeight = (_spriteRenderer.sprite.texture.height / _spriteRenderer.sprite.pixelsPerUnit) * this.transform.localScale.y;
            _textureSize = new Vector2(textureWidth, textureHeight);
            _startPos = this.transform.localPosition;
        }

        /// <summary>
        /// Sets the sorting layer and sorting order of the SpriteRenderer.
        /// </summary>
        public void SetSortingOrder(LayerMask sortingLayer, int order)
        {
            _spriteRenderer.sortingLayerID = sortingLayer;
            _spriteRenderer.sortingOrder = order;
        }

        /// <summary>
        /// Sets the value for the parallax multiplier.
        /// </summary>
        public void SetParallaxMultiplier(float multiplier) => _parallaxMultiplier = multiplier;

        /// <summary>
        /// Updates the position of the parallax layer.
        /// </summary>
        public void UpdatePosition(Vector3 target)
        {
            // Calculates the distance relative to the start point.
            Vector2 distanceFromStart = new Vector2(target.x * _parallaxMultiplier,
                target.y * _parallaxMultiplier);

            // Updates the position of the layer using the parallax multiplier. Checks whether the position should be updated horizontally and vertically depending on the settings.
            float newPosX = HorizontalParallax ? _startPos.x + distanceFromStart.x : this.transform.localPosition.x;
            float newPosY = VerticalParallax ? _startPos.y + distanceFromStart.y : this.transform.localPosition.y;
            this.transform.localPosition = new Vector3(newPosX, newPosY, this.transform.localPosition.z);

            // Calculates how far the layer has moved relative to the target.
            Vector2 relativeToTarget = target - this.transform.position;

            // Updates the position of the layer to keep it in the frame if the position relative to the target has exceeded the starting position plus the sprite size in any direction.
            if (relativeToTarget.x > _textureSize.x)
                _startPos += new Vector2(_textureSize.x, 0);
            else if (relativeToTarget.x < - _textureSize.x)
                _startPos -= new Vector2(_textureSize.x, 0);

            if (relativeToTarget.y > _textureSize.y)
                _startPos += new Vector2(0, _textureSize.y);
            else if (relativeToTarget.y < - _textureSize.y)
                _startPos -= new Vector2(0, _textureSize.y);
        }
    }
}