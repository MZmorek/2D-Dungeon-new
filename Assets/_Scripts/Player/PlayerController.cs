using UnityEngine;

namespace Dungeons.Player
{
    public class PlayerController : MonoBehaviour
    {
        public LayerMask groundLayerMask;

        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;

        private Collider2D playerCollider;
        private Rigidbody2D playerRigidbody;

        private float raycastLength = 0.6f;
        private float horizontalInput;
        public float HorizontalInput { get { return horizontalInput; } }

        private bool jumpInput;

        public bool JumpInput { get { return jumpInput; } }

        private bool active = false;
        public bool IsActive { get { return active; } }

        public bool isGrounded;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (!active)
            {
                return;
            }
            CheckInput();
            ApplyMovement();
        }

        public void SwitchState(bool state)
        {
            active = state;

            if (playerRigidbody != null)
            {
                playerRigidbody.simulated = state;
            }
        }

        #region Movement Conditions Methods

        private void CheckInput()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetKeyDown(KeyCode.Space);
        }

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, raycastLength, groundLayerMask);
            isGrounded = hit.collider != null;
            //Debug.DrawRay(playerCollider.bounds.center, Vector2.down * raycastLength, isGrounded ? Color.green : Color.red, 0.5f);
            return isGrounded;
        }

        #endregion

        #region MovementMethods

        private void ApplyMovement()
        {
            ApplyHorizontalMovement();
            Jump();
        }

        private void ApplyHorizontalMovement()
        {
            playerRigidbody.velocity = new Vector2(movementSpeed * horizontalInput, playerRigidbody.velocity.y);
        }

        private void Jump()
        {
            if (jumpInput && IsGrounded())
            {
                playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        #endregion
    }
}