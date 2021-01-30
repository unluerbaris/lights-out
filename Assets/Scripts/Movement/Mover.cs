using UnityEngine;

namespace LightsOut.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 2f;

        Vector2 normalizedVelocity;

        Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float controlThrowX, float controlThrowY)
        {
            normalizedVelocity = new Vector2(controlThrowX, controlThrowY).normalized;
            rb2D.velocity = normalizedVelocity * speed;
            FlipCharacter();
        }

        private void FlipCharacter()
        {
            bool playerHasHorizontalSpeed = Mathf.Abs(rb2D.velocity.x) > Mathf.Epsilon;
            if (playerHasHorizontalSpeed)
            {
                transform.localScale = new Vector2(-Mathf.Sign(rb2D.velocity.x), 1f);
            }
        }
    }
}
