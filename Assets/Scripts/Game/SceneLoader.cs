using UnityEngine;
using UnityEngine.SceneManagement;

namespace PirateGame.Game
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int index)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(index);
        }
    }
}

