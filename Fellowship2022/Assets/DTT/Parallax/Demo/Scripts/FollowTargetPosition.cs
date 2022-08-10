using UnityEngine;

namespace DTT.Parallax.Demo
{
    /// <summary>
    /// Class that allows the current object to follow the current position of another.
    /// </summary>
    public class FollowTargetPosition : MonoBehaviour
    {
        /// <summary>
        /// The target object to follow.
        /// </summary>
        [SerializeField]
        private Transform _target;

        /// <summary>
        /// The offset for the target position.
        /// </summary>
        [SerializeField]
        private Vector2 _offset;

        /// <summary>
        /// Whether to follow or not follow the target movement on the X axis.
        /// </summary>
        [SerializeField]
        private bool _followOnXAxis;

        /// <summary>
        /// Whether to follow or not follow the target movement on the Y axis.
        /// </summary>
        [SerializeField]
        private bool _followOnYAxis;

        /// <summary>
        /// Store the current position on the X axis.
        /// </summary>
        private float _xPos;

        /// <summary>
        /// Store the current position on the Y axis.
        /// </summary>
        private float _yPos;

        /// <summary>
        /// Set the current object's position to the target's position.
        /// </summary>
        private void OnEnable() => transform.position = new Vector3(_target.position.x + _offset.x, _target.transform.position.y + _offset.y, transform.position.z);

        /// <summary>
        /// Updates the current object's position to the target's position.
        /// </summary>
        private void Update()
        {    
            _xPos = _followOnXAxis ? _target.position.x + _offset.x : transform.position.x;
            _yPos = _followOnYAxis ? _target.position.y + _offset.y : transform.position.y;
            transform.position = new Vector3(_xPos, _yPos, transform.position.z);
        }
    }
}
