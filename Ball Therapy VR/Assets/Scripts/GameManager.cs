using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject floor;

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
        if(floor != null)
        {
            floor.GetComponent<Rigidbody>().useGravity = true;  // make floor fall down
        }
        winCanvas.SetActive(true);
    }
}
