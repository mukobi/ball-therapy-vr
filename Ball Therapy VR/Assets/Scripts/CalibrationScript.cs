using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class CalibrationScript : MonoBehaviour
{
    bool armLengthDone = false;
    bool shoulderDone = false;
    private float armDist;

    public GameObject winCanvas;
    public GameObject cameraRig;
    public GameObject leftController;
    public GameObject rightController;
    public Text displayText;

    // Update is called once per frame
    void Update()
    {
        armDist = Vector3.Distance(leftController.transform.position, rightController.transform.position);
        displayText.text = "Measured: " + armDist.ToString("N3") + " m";

        if(SteamVR_Input.GetBooleanAction("InteractUI").state)  // interact button pressed
        {
            gameObject.SetActive(false);  // stop displaying calibration
            GameState.armSpan = armDist;
            winCanvas.SetActive(true);
        }
    }
}
