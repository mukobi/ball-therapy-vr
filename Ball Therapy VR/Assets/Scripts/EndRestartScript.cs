using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class EndRestartScript : MonoBehaviour
{
    private bool done = false;
    void Update()
    {
        if (!done && SteamVR_Actions.default_InteractUI[SteamVR_Input_Sources.LeftHand].state
            && SteamVR_Actions.default_InteractUI[SteamVR_Input_Sources.RightHand].state)  // interact button pressed
        {
            done = true;
            GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
            foreach (GameManager gm in allGameManagers)
            {
                if (gm.gameObject.scene == gameObject.scene)
                {
                    gm.GoToStart();  // back to calibration
                }
            }
        }
    }
}
