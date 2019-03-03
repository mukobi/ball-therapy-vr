using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvasScript : MonoBehaviour
{
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
