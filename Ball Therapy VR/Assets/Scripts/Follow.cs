using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject toFollow;
    public Vector3 offset;
    private float lerpFactor = 0.8f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + offset, lerpFactor);
    }
}
