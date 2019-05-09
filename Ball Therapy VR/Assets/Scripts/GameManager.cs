using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        FadeScreenIn();
    }

    [ContextMenu("Go To Next Level")]
    public void GoToNextLevel()
    {
        GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    [ContextMenu("Go To Random Playable Level")]
    public void GoToRandomPlayableLevel()
    {
        GoToLevel(new System.Random().Next(1,5));
    }

    public void GoToLevel(int levelNum)
    {
        StartCoroutine(GoToLevelRoutine(levelNum));
    }

    private IEnumerator GoToLevelRoutine(int levelNum)
    {
        GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
        foreach (GameManager gm in allGameManagers)
        {
            if (gm != this)
            {
                Debug.Log("Destroyed " + gm.gameObject.name);
                Destroy(gm.gameObject);
            }
        }

        // need to yield a frame to destroy of GM before loading next
        yield return null;
        string[] scenesList = { "Calibration", "Level 1", "Level 2", "Level 3", "Level 4", "Endgame" };
        if (levelNum < scenesList.Length)
        {
            StopMusic();
            PlayEndVO();
            FadeScreenOut();
            string nextLevelName = scenesList[levelNum];
            Debug.Log("Loading: " + nextLevelName);
            GetComponent<SteamVR_LoadLevel>().levelName = nextLevelName;
            GetComponent<SteamVR_LoadLevel>().Trigger();
        }
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
        Debug.Log("Fade Screen Out");
        SteamVR_Fade.Start(Color.clear, 0f, true);
        SteamVR_Fade.Start(Color.black, GetComponent<SteamVR_LoadLevel>().fadeOutTime, true);
    }
    private void FadeScreenIn()
    {
        Debug.Log("Fade Screen In");
        SteamVR_Fade.Start(Color.black, 0f, true);
        SteamVR_Fade.Start(Color.clear, GetComponent<SteamVR_LoadLevel>().fadeInTime, true);
    }
}
