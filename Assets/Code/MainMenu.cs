using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class MainMenu:MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}