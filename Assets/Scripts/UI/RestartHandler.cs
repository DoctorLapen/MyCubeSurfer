using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyCubeSurfer
{
    public class RestartHandler : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}