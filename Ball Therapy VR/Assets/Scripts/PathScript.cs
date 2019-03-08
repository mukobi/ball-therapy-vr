using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PathScript : MonoBehaviour
{
    private float ballTime = 0.0f;
    private float diffTime;
    public Material matOn;
    public Material matOff;
    public bool isLeft = false;
    public float armSpanDividend = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //float zOffset = isLeft ? -(GameState.armSpan) : (GameState.armSpan);
        //gameObject.transform.position += new Vector3(0, 0, zOffset / armSpanDividend);
        
        foreach(Transform obj in transform)
        {
            obj.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // triggered when the next ball in the path to be hit is hit
    public void advancePath()
    {
        //if (ballTime == 0.0f)
        //{
        //    ballTime = Time.time;

        //}
        //else {
        //    diffTime = Time.time - ballTime;
        //    ballTime = Time.time;
        //}
        if(transform.childCount == 1)
        {
            if (isLeft) GameState.leftDone = true;
            else GameState.rightDone = true;
            FindObjectOfType<GameManager>().CheckWin();
            Destroy(gameObject);
            return;
        }
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
