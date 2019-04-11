using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.SceneManagement;

public class CalibrationScript : MonoBehaviour
{
    private float armDist;
    
    public GameObject leftController;
    public GameObject rightController;
    public Text displayText;

    private bool doneCalibrating = false;

    // Update is called once per frame
    void Update()
    {
        armDist = Vector3.Distance(leftController.transform.position, rightController.transform.position);
        displayText.text = "Measured Arm Span: " + armDist.ToString("N3") + " m";

        if(!doneCalibrating && SteamVR_Input.GetBooleanAction("InteractUI").state)  // interact button pressed
        {
            doneCalibrating = true;
            GameState.armSpan = armDist / 2.0f;
            FindObjectOfType<GameManager>().GoToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
