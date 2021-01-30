using UnityEngine;

namespace LightsOut.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 2f;

        float positionX;
        float positionY;

        private void Awake()
        {
            positionX = transform.position.x;
            positionY = transform.position.y;
        }

        public void Move(float controlThrowX, float controlThrowY)
        {
            positionX = positionX + Time.deltaTime * speed * controlThrowX;
            positionY = positionY + Time.deltaTime * speed * controlThrowY;

            transform.position = new Vector2(positionX, positionY);
        }
    }
}
