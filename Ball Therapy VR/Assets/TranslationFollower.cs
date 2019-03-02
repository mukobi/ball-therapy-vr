using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationFollower : MonoBehaviour
{
    public GameObject toFollow;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Follower collided with: " + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = toFollow.transform.position;
    }
}
