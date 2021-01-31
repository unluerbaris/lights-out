using UnityEngine;
using UnityEngine.UI;

namespace LightsOut.Environment
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] objects;
        [SerializeField] Text numOfItemsCollected;
        [SerializeField] Text totalNumOfItems;
        [SerializeField] GameObject winScreen;

        int objectIndex = 0;

        void Awake()
        {
            SpawnObject();
            totalNumOfItems.text = objects.Length.ToString();
        }

        public void SpawnObject()
        {
            numOfItemsCollected.text = objectIndex.ToString();

            if (objectIndex >= objects.Length)
            {
                winScreen.SetActive(true);
                Time.timeScale = 0;
                return;
            }

            int randomIndex = Random.Range(0, transform.childCount - 1);
        
            GameObject objectInstance = Instantiate(objects[objectIndex], transform.GetChild(randomIndex).position, Quaternion.identity) as GameObject;
            objectIndex++;
        }
    }
}
