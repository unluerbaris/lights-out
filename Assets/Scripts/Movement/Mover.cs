using UnityEngine;

namespace LightsOut.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 2f;

        Vector2 velocity;

        Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float controlThrowX, float controlThrowY)
        {
            velocity = new Vector2(controlThrowX * speed, controlThrowY * speed);
            rb2D.velocity = velocity;
        }
    }
}
