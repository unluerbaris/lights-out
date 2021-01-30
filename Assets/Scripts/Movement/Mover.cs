using UnityEngine;

namespace LightsOut.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 2f;

        Vector2 normalizedVelocity;
        bool playerHasHorizontalSpeed;
        bool playerHasVerticalSpeed;

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
            playerHasHorizontalSpeed = Mathf.Abs(rb2D.velocity.x) > 0.1;
            playerHasVerticalSpeed = Mathf.Abs(rb2D.velocity.y) > 0.1;

            if (playerHasHorizontalSpeed)
            {
                transform.localScale = new Vector2(-Mathf.Sign(rb2D.velocity.x), 1f);
            }
        }
    }
}
