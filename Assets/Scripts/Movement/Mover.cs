using UnityEngine;

namespace LightsOut.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 2f;

        Vector2 normalizedVelocity;
        bool playerHasHorizontalSpeed;
        bool playerHasVerticalSpeed;
        bool isFacingRight = true;

        Rigidbody2D rb2D;
        Animator myAnimator;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
        }

        public void Move(float controlThrowX, float controlThrowY)
        {
            normalizedVelocity = new Vector2(controlThrowX, controlThrowY).normalized;
            rb2D.velocity = normalizedVelocity * speed;
            myAnimator.SetBool("isMoving", playerHasHorizontalSpeed || playerHasVerticalSpeed);
            FlipCharacter();
        }

        private void FlipCharacter()
        {
            bool isFacingLeft = rb2D.velocity.x < 0;

            playerHasHorizontalSpeed = Mathf.Abs(rb2D.velocity.x) > 0.1;
            playerHasVerticalSpeed = Mathf.Abs(rb2D.velocity.y) > 0.1;

            if (playerHasHorizontalSpeed && Mathf.Sign(rb2D.velocity.x) == -1 && isFacingRight)
            {
                isFacingRight = false;
                transform.Rotate(0f, 180f, 0f);
            }
            else if (playerHasHorizontalSpeed && Mathf.Sign(rb2D.velocity.x) == 1 && !isFacingRight)
            {
                isFacingRight = true;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }
}
