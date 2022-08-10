using System.Collections.Generic;
using UnityEngine;

namespace DTT.Parallax
{
    /// <summary>
    /// Class that handles the movements of each parallax layer to create a dynamic background effect.
    /// </summary>
    public class ParallaxManager : MonoBehaviour
    {
        /// <summary>
        /// The reference transform used to move the layers relative to it's position for the dynamic movement.
        /// </summary>
        [SerializeField]
        [Tooltip("The reference transform used to move the layers relative to it's position for the parallax movement")]
        private Transform _camera;

        /// <summary>
        /// The sorting layer name for the parallax items.
        /// </summary>
        [SerializeField]
        [Tooltip("The sorting layer name for the parallax items")]
        private LayerMask _sortingLayer;

        /// <summary>
        /// Whether the layers should be instantiated.
        /// </summary>
        [SerializeField]
        [Tooltip("Whether the layers should be instantiated")]
        private bool _instantiateLayers = true;

        /// <summary>
        /// Whether the layers parallax multiplier should be set automatically on start. 
        /// The multiplier value will be assigned according to the order of the _layers.
        /// </summary>
        [SerializeField]
        [Tooltip("Whether the layers parallax multiplier should be set automatically. The multiplier value will be assigned according to the order of the _layers.")]
        private bool _setMultipliersAutomatically = true;

        /// <summary>
        /// The layers of the parallax.
        /// </summary>
        [SerializeField]
        [Tooltip("The layers of the parallax")]
        private List<ParallaxLayer> _layers;

        /// <summary>
        /// Sets up the required values for the layers, such as the size of the sprite and starting position.
        /// </summary>
        private void OnEnable()
        {
            // Saves the group rotation.
            Quaternion groupRotation = this.transform.localRotation;
            this.transform.rotation = Quaternion.identity;

            // Instantiates the layer objects.
            for (int i = 0; i < _layers.Count; i++)
            {
                if (_instantiateLayers)
                    _layers[i] = Instantiate(_layers[i]);

                _layers[i].transform.parent = this.transform;
                _layers[i].SetSortingOrder(_sortingLayer, i);

                if (_setMultipliersAutomatically)
                    _layers[i].SetParallaxMultiplier(1 - (1 / (float)_layers.Count * i));
            }

            this.transform.rotation = groupRotation;
        }

        /// <summary>
        /// Updates the position of each layer.
        /// </summary>
        private void Update()
        {
            for (int i = 0; i < _layers.Count; i++)
                _layers[i].UpdatePosition(_camera.localPosition);
        }
    }
}