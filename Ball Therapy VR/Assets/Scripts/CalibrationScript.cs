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
        float cameraRigScale = FindObjectOfType<SteamVR_PlayArea>().transform.localScale.x;
        height = playerCamera.transform.position.y / cameraRigScale;
        Debug.Log("Height: " + height);
        doneCalibrating = true;
        GameState.armSpan = height / 2.0f;
        FindObjectOfType<GameManager>().GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
