using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public void CheckSyncedPathTrigger()
    {
        PathScript first = transform.GetChild(0).GetComponent<PathScript>();
        PathScript second = transform.GetChild(1).GetComponent<PathScript>();
        if (first.FirstBallHit &&
            second.FirstBallHit)
        {
            first.AdvancePath();
            second.AdvancePath();
        }
    }
}
