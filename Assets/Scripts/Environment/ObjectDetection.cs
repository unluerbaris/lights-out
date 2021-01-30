using UnityEngine;

namespace LightsOut.Environment
{
    public class ObjectDetection : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Thats a {collision.gameObject.name}");
        }
    }
}
