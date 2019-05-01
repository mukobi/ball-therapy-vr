using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    GameManager instance = null;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else instance = this;
        FadeScreenIn();
    }

    [ContextMenu("Go To Next Level")]
    public void GoToNextLevel()
    {
        GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToLevel(int levelNum)
    {
        StopMusic();
        PlayEndVO();
        FadeScreenOut();
        string[] scenesList = { "Calibration", "Level 1", "Level 2", "Level 3", "Level 4", "Endgame" };
        string nextLevelName = scenesList[levelNum];
        Debug.Log("Loading: " + nextLevelName);
        GetComponent<SteamVR_LoadLevel>().levelName = nextLevelName;
        GetComponent<SteamVR_LoadLevel>().Trigger();
    }

    void StopMusic()
    {
        FindObjectOfType<MusicManager>().StopMusic();
    }

    void PlayEndVO()
    {
        FindObjectOfType<VOManager>().PlayEndClip();
    }

    private void FadeScreenOut()
    {
        SteamVR_Fade.Start(Color.black, GetComponent<SteamVR_LoadLevel>().fadeOutTime, true);
    }
    private void FadeScreenIn()
    {
        SteamVR_Fade.Start(Color.black, 0f, true);
        SteamVR_Fade.Start(Color.clear, GetComponent<SteamVR_LoadLevel>().fadeInTime, true);
    }
}
