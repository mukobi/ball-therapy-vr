using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public GameObject objectToTrigger;
    public Material matOn;
    public Material matOff;
    private int currIndex = 0;
    private int childCount = 0;
    // Start is called before the first frame update
    void Start()
    {
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
            currIndex %= transform.childCount;
            transform.GetChild(currIndex).gameObject.GetComponent<Renderer>().material = matOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
