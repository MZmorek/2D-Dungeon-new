using UnityEngine;

namespace Dungeons.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;

        private Rigidbody2D playerRigidbody;

        private float horizontalInput;
        private bool jumpInput;
        private bool isJumping = false;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckInput();
            ApplyMovement();
        }

        #region MovementMethods

        private void CheckInput()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetKeyDown(KeyCode.Space);
        }

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
            if (jumpInput)
            {
                playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = false;
            }
        }
        #endregion
    }
}