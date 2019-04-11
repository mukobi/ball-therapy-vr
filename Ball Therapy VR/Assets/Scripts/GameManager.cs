using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    private float _fadeDuration = 5f;

    private void Start()
    {
        FadeFromWhite();
        GameState.leftDone = false;
        GameState.rightDone = false;
        Debug.Log("GameManager Started. " + Time.time);
    }
    
    public void CheckWin()
    {
        if(GameState.leftDone && GameState.rightDone)
        {
            GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void GoToLevel(int levelNum)
    {
        StopMusic();
        FadeToWhite();
        string[] scenesList = { "Calibration", "Level 1", "Level 2", "Level 3", "Level 4", "Endgame" };
        string nextLevelName = scenesList[levelNum];
        Debug.Log("Loading: " + nextLevelName);
        GetComponent<SteamVR_LoadLevel>().levelName = nextLevelName;
        GetComponent<SteamVR_LoadLevel>().Trigger();
        //Invoke("LoadNextLevel", 6f);
    }

    void StopMusic()
    {
        FindObjectOfType<MusicManager>().StopMusic();
    }

    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, _fadeDuration);
    }
    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }
}
