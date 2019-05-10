using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class CalibrationScript : MonoBehaviour
{
    private float height;

    public GameObject playerCamera;

    private bool doneCalibrating = false;

    // Update is called once per frame
    void Update()
    {
        if (!doneCalibrating
            && SteamVR_Actions.default_InteractUI[SteamVR_Input_Sources.LeftHand].state
            && SteamVR_Actions.default_InteractUI[SteamVR_Input_Sources.RightHand].state)
        {
            FinishCalibration();
        }
    }
    void FinishCalibration()
    {
        doneCalibrating = true;
        GameState.armSpan = playerCamera.transform.localPosition.y / 2.0f;
        Debug.Log("Armspan: " + GameState.armSpan);
        GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
        foreach (GameManager gm in allGameManagers)
        {
            if (gm.gameObject.scene == gameObject.scene)
            {
                gm.GoToRandomPlayableLevel();
                return;
            }
        }
    }
}
