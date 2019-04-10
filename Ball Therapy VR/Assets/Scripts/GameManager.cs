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
            EndLevel();
        }
    }

    public void EndLevel()
    {
        StopMusic();
        FadeToWhite();
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        string[] scenesList = { "Calibration", "Level 1", "Level 2", "Level 3", "Level 4", "Endgame" };
        string nextLevelName = scenesList[index];
        Debug.Log("Loading: " + nextLevelName);
        GetComponent<SteamVR_LoadLevel>().levelName = nextLevelName;
        GetComponent<SteamVR_LoadLevel>().Trigger();
        //Invoke("LoadNextLevel", 6f);
    }

    void StopMusic()
    {
        FindObjectOfType<MusicManager>().StopMusic();
    }

    //void LoadNextLevel()
    //{
    //    //Debug.Log("Start loading next level. " + Time.time);
    //    StartCoroutine(LoadNextAsyncScene());
    //}

    //private IEnumerator LoadNextAsyncScene()
    //{
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    //    // Wait until the asynchronous scene fully loads
    //    while (!asyncLoad.isDone)
    //    {
    //        //Debug.Log("Async loading. " + Time.time);
    //        yield return null;
    //    }
    //}

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
