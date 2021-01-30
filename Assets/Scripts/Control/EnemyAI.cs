using UnityEngine;

namespace LightsOut.Control
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] float stoppingDistance = 1f;
        [SerializeField] float escapeTime = 5f;

        bool isScared = false;
        float escapeTimer = Mathf.Infinity;
        
        Transform playerTransform;

        private void Awake()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            escapeTimer += Time.deltaTime;

            if (!isScared && Vector2.Distance(transform.position, playerTransform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
            else
            {
                if (escapeTimer > escapeTime)
                {
                    isScared = false;
                }
                transform.position = Vector2.MoveTowards(transform.position, -playerTransform.position, speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isScared && collision.gameObject.tag == "Player")
            {
                isScared = true;
                escapeTimer = 0;
            }
        }
    }
}
