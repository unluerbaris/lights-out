using UnityEngine;
using UnityEngine.SceneManagement;

namespace LightsOut.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1;
        }

        public void LoadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
