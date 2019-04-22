using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject toFollow;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = toFollow.transform.position + offset;
    }
}
