using System.Collections;
using UnityEngine;

namespace DTT.Parallax.Demo
{
    /// <summary>
    /// Class that handles the movement of the player.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// The speed at which the player can move.
        /// </summary>
        [SerializeField]
        private float _movementSpeed;

        /// <summary>
        /// The speed at which the player can jump.
        /// </summary>
        [SerializeField]
        private float _jumpSpeed;

        /// <summary>
        /// The time in seconds for how often the player is allowed to jump.
        /// </summary>
        [SerializeField]
        private float _jumpCooldown;

        /// <summary>
        /// Wobble effect intensity.
        /// </summary>
        [SerializeField]
        private float _wobbleEffectIntensity = 10f;

        /// <summary>
        /// The scaling degree of the wobble.
        /// </summary>
        [SerializeField]
        private float _wobbleScaleDelta = 0.01f;

        /// <summary>
        /// Cached wobble value.
        /// </summary>
        private float _wobble = 0f;

        /// <summary>
        /// The value of the input on the x axis.
        /// </summary>
        private float _inputX = 1;

        /// <summary>
        /// Whether the player is currently jumping.
        /// </summary>
        private bool _jumping;

        /// <summary>
        /// The sprite renderer component of the object.
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// The Rigidbody2D component of the object.
        /// </summary>
        private Rigidbody2D _rigidbody2D;

        /// <summary>
        /// Sets the references to the object components.
        /// </summary>
        private void Awake()
        {
            _rigidbody2D = this.GetComponent<Rigidbody2D>();
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Checks the player's input to update the movement values.
        /// </summary>
        private void Update() => CheckPlayerInput();

        /// <summary>
        /// Makes the player jump and disables jumping for an amount of time.
        /// </summary>
        private IEnumerator JumpAction()
        {
            _jumping = true;
            _rigidbody2D.AddForce(transform.up * _jumpSpeed);
            yield return new WaitForSeconds(_jumpCooldown);
            _jumping = false;
        }

        /// <summary>
        /// Updates the player's position according to the input.
        /// </summary>
        private void FixedUpdate()
        {
            // If no input is detected then do not update the position.
            if (_inputX == 0f)
                return;
            
            Wobble();
            Vector3 movement = new Vector3(_movementSpeed * _inputX, 0, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);
        }

        /// <summary>
        /// Checks the player input to trigger the actions for the player.
        /// </summary>
        private void CheckPlayerInput()
        {
            // Checks the player input to move the object.
            _inputX = Input.GetAxis("Horizontal");

            _spriteRenderer.flipX = _inputX < 0 ? true : false;

            // Checks the player input to trigger the jumping action.
            if (!_jumping && Input.GetAxis("Vertical") > 0)
                StartCoroutine(JumpAction());
        }

        /// <summary>
        /// Adds a wobble effect to the player character.
        /// </summary>
        private void Wobble()
        {
            _wobble += Time.fixedDeltaTime * _wobbleEffectIntensity;
            float currentYScale = transform.localScale.y;
            currentYScale += _wobbleScaleDelta * Mathf.Sin(_wobble);
            transform.localScale = new Vector3(transform.localScale.x, currentYScale, transform.localScale.y);
        }
    }
}
