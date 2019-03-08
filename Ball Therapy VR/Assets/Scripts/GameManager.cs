using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winCanvas;

    private void Start()
    {
        GameState.leftDone = false;
        GameState.rightDone = false;
    }
    
    public void CheckWin()
    {
        if(GameState.leftDone && GameState.rightDone)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        Debug.Log("done");
        winCanvas.SetActive(true);
    }
}
