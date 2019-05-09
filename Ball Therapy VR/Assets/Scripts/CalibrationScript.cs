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
        height = playerCamera.transform.localPosition.y;
        Debug.Log("Height: " + height);
        doneCalibrating = true;
        GameState.armSpan = height / 2.0f;
        GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
        foreach (GameManager gm in allGameManagers)
        {
            if (gm.gameObject.scene == gameObject.scene)
            {
                gm.GoToNextLevel();
                return;
            }
        }
    }
}
