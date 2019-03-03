using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    private int currIndex = 0;
    private int childCount = 0;
    public GameObject objectToTrigger;
    public Material matOn;
    public Material matOff;
    public bool isLeft = false;
    public float armSpanDividend = 4f;
    // Start is called before the first frame update
    void Start()
    {
        float zOffset = isLeft ? -(GameState.armSpan) : (GameState.armSpan);
        gameObject.transform.position += new Vector3(0, 0, zOffset / armSpanDividend);

        childCount = transform.childCount;
        foreach(Transform obj in transform)
        {
            obj.gameObject.GetComponent<Renderer>().material = matOff;
        }
        transform.GetChild(currIndex).gameObject.GetComponent<Renderer>().material = matOn;
    }

    public void advancePath(GameObject childObject)
    {
        int index = childObject.transform.GetSiblingIndex();
        if(index != -1 && index == currIndex)
        {
            transform.GetChild(currIndex).gameObject.GetComponent<Renderer>().material = matOff;
            currIndex++;
            if(currIndex == transform.childCount)
            {
                if (isLeft) GameState.leftDone = true;
                else GameState.rightDone = true;
                FindObjectOfType<GameManager>().CheckWin();
                Destroy(gameObject);
                return;
            }
            transform.GetChild(currIndex).gameObject.GetComponent<Renderer>().material = matOn;
        }
    }
}
