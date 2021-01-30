using LightsOut.Movement;
using UnityEngine;

namespace LightsOut.Control
{
    public class PlayerController : MonoBehaviour
    {
        float controlThrowX;
        float controlThrowY;

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
    }
}
