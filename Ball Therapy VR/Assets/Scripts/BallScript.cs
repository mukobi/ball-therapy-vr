using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string triggerTag = gameObject.GetComponentInParent<PathScript>().isLeft ? "Left Controller" : "Right Controller";
        Debug.Log("Look for " + triggerTag + ", found " + other.tag);
        if (other.tag == triggerTag && transform.GetSiblingIndex() == 0) 
        {
            gameObject.GetComponentInParent<PathScript>().advancePath();
            Explode();
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
