using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollow : MonoBehaviour
{
    public GameObject toFollow;
    public Vector3 offset;
    public float lerpFactor;
    private LineRenderer lineRenderer;

    void Start()
    {
        // set up line renderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = gameObject.GetComponent<MeshRenderer>().material;
        Debug.Log("lineRenderer.material");
        lineRenderer.widthMultiplier = 0.01f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + offset, Time.deltaTime * lerpFactor);
        // draw line from hand to controller it's following
        lineRenderer.SetPosition(0, toFollow.transform.position);
        lineRenderer.SetPosition(1, gameObject.transform.position);
    }
}
