using UnityEngine;

namespace LightsOut.Environment
{
    public class ObjectDetection : MonoBehaviour
    {
        ObjectSpawner objectSpawner;

        private void Awake()
        {
            objectSpawner = FindObjectOfType<ObjectSpawner>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            objectSpawner.SpawnObject();
        }

        ////////////// Implement Later /////////
        //[SerializeField] GameObject objectInfoCanvas;
        //bool isTextExist = false;

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (objectInfoCanvas == null) return;
        //    if (isTextExist) return;

        //    Debug.Log($"Thats a {collision.gameObject.name}");
        //    isTextExist = true;
        //    GameObject infoCanvasInstance = Instantiate(objectInfoCanvas, collision.transform.position, Quaternion.identity) as GameObject;
        //    infoCanvasInstance.gameObject.transform.parent = collision.transform;
        //}

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        Debug.Log("Show SOME TEXT");
        //    }
        //}

        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    Destroy(collision.gameObject.transform.GetChild(collision.transform.childCount - 1).gameObject);
        //    isTextExist = false;
        //}
    }
}
