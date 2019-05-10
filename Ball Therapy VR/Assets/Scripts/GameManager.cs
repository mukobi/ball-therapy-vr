using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    private readonly string[] scenesList = { "Calibration", "Level 1", "Level 2", "Level 3", "Endgame" };

    private void Start()
    {
        FadeScreenIn();
    }

    [ContextMenu("Go To Start/Calibration")]
    public void GoToStart()
    {
        GoToLevel(0);
    }

    [ContextMenu("Go To Next Level")]
    public void GoToNextLevel()
    {
        GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    [ContextMenu("Go To Random Playable Level")]
    public void GoToRandomPlayableLevel()
    {
        System.Random random = new System.Random();
        int index;
        do
        {
            index = random.Next(1, scenesList.Length - 1);
        } while (index == GameState.lastLevelIndex);
        GameState.lastLevelIndex = index;
        GoToLevel(index);
    }

    [ContextMenu("Go To End")]
    public void GoToEnd()
    {
        GoToLevel(scenesList.Length - 1);
    }

    private void GoToLevel(int levelNum)
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

        // need to yield a frame to destroy old GM before loading next
        yield return null;
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
