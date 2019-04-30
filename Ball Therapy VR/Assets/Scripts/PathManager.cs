using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    private PathScript first;
    private PathScript second;
    private void Start()
    {
        first = transform.GetChild(0).GetComponent<PathScript>();
        second = transform.GetChild(1).GetComponent<PathScript>();
    }

    public void CheckSyncedPathTrigger()
    {
        if (first.FirstBallHit &&
            second.FirstBallHit)
        {
            first.AdvancePath();
            second.AdvancePath();
        }
    }
}
