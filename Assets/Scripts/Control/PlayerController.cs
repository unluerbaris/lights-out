using LightsOut.Movement;
using UnityEngine;

namespace LightsOut.Control
{
    public class PlayerController : MonoBehaviour
    {
        float controlThrowX;
        float controlThrowY;

        [SerializeField] GameObject loseScreen;

        Mover mover;

        private void Awake()
        {
            mover = GetComponent<Mover>();
        }

        private void FixedUpdate()
        {
            MoveInput();
        }

        private void MoveInput()
        {
            controlThrowX = Input.GetAxis("Horizontal"); //-1 to +1
            controlThrowY = Input.GetAxis("Vertical"); //-1 to +1
            mover.Move(controlThrowX, controlThrowY);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                loseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
