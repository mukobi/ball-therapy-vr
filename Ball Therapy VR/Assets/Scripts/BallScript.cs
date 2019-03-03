using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.GetComponentInParent<PathScript>().objectToTrigger.tag == other.tag)
        {
            gameObject.GetComponentInParent<PathScript>().advancePath(gameObject);
        }
    }
}
