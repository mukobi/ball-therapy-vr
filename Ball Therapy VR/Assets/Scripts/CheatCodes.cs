using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CheatCodes : MonoBehaviour
{

    private bool cheatActivated = false;

    private void Update()
    {
        if(!cheatActivated) { 
            if (SteamVR_Actions.default_Teleport[SteamVR_Input_Sources.LeftHand].state &&
                SteamVR_Actions.default_Teleport[SteamVR_Input_Sources.RightHand].state) // Teleport -> restart
            {
                Debug.Log("Double teleport");
                GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
                foreach (GameManager gm in allGameManagers)
                {
                    if (gm.gameObject.scene == gameObject.scene)
                    {
                        cheatActivated = true;
                        gm.GoToLevel(0);
                    }
                }
            }
            else if (SteamVR_Actions.default_GrabGrip[SteamVR_Input_Sources.LeftHand].state &&
                        SteamVR_Actions.default_GrabGrip[SteamVR_Input_Sources.RightHand].state) // grip -> Next Level
            {
                Debug.Log("Double grip");
                GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
                foreach (GameManager gm in allGameManagers)
                {
                    if (gm.gameObject.scene == gameObject.scene)
                    {
                        cheatActivated = true;
                        gm.GoToNextLevel();
                    }
                }
            }
        }
    }
}
