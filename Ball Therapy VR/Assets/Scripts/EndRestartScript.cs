using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class EndRestartScript : MonoBehaviour
{
    private bool done = false;
    void Update()
    {
        if (!done && SteamVR_Input.GetBooleanAction("InteractUI").state)  // interact button pressed
        {
            done = true;
            FindObjectOfType<GameManager>().GoToLevel(0);  // back to calibration
        }
    }
}
