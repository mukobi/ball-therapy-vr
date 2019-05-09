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
            if (SteamVR_Actions.default_GrabGrip[SteamVR_Input_Sources.LeftHand].state &&
                SteamVR_Actions.default_GrabGrip[SteamVR_Input_Sources.RightHand].state) // grip -> restart
            {
                Debug.Log("Double grip");
                GameManager[] allGameManagers = FindObjectsOfType<GameManager>();
                foreach (GameManager gm in allGameManagers)
                {
                    if (gm.gameObject.scene == gameObject.scene)
                    {
                        cheatActivated = true;
                        gm.GoToStart();
                    }
                }
            }
            else if (SteamVR_Actions.default_Teleport[SteamVR_Input_Sources.LeftHand].state &&
                        SteamVR_Actions.default_Teleport[SteamVR_Input_Sources.RightHand].state) // teleport -> Next Level
            {
                Debug.Log("Double teleport");
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
