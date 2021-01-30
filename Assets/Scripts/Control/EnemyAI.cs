using LightsOut.Movement;
using UnityEngine;

namespace LightsOut.Control
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] float stoppingDistance = 1f;

        Transform playerTransform;

        private void Awake()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
    }
}
