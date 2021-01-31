using UnityEngine;

namespace LightsOut.Environment
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] objects;

        int objectIndex = 0;

        void Awake()
        {
            SpawnObject();
        }

        private void SpawnObject()
        {
            if (objectIndex >= objects.Length) return;

            int randomIndex = Random.Range(0, transform.childCount - 1);
        
            GameObject objectInstance = Instantiate(objects[objectIndex], transform.GetChild(randomIndex).position, Quaternion.identity) as GameObject;
            objectIndex++;
        }
    }
}
