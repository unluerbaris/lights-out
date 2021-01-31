using UnityEngine;

namespace LightsOut.Control
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] float stoppingDistance = 1f;
        [SerializeField] float escapeTime = 5f;

        float speedMultiplier = 1f;

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
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * speedMultiplier * Time.deltaTime);
            }
            else
            {
                if (escapeTimer > escapeTime)
                {
                    isScared = false;
                }

                transform.position = Vector2.MoveTowards(transform.position,
                                                         -playerTransform.position * 100,
                                                         speed * speedMultiplier * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isScared && collision.gameObject.tag == "Player")
            {
                speedMultiplier = Random.Range(1.5f, 3f);
                Debug.Log(speedMultiplier);
                isScared = true;
                escapeTimer = 0;
            }
        }
    }
}
