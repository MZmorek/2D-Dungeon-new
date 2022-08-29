using UnityEngine;

namespace Dungeons.Player
{

    public class AnimationController : MonoBehaviour
    {
        public Animator playerAnimator;
        public SpriteRenderer playerSprite;
        private bool flipSprite = false;
        private PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }

        void Update()
        {
            Flip();
            PlayRunningAnimation();
        }

        private void Flip()
        {
            if (!playerController.IsActive)
            {
                return;
            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1;
                flipSprite = true;
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1;
                flipSprite = false;
            }

            playerSprite.flipX = flipSprite;
        }

        private void PlayRunningAnimation()
        {
            if (playerController.HorizontalInput != 0)
            {
                playerAnimator.SetBool("isRunning", true);
            }
            if (playerController.HorizontalInput == 0)
            {
                playerAnimator.SetBool("isRunning", false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            playerAnimator.SetBool("isJumping", false);
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            playerAnimator.SetBool("isJumping", true);
        }
    }
}