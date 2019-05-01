using System.Collections;
using UnityEngine;

public class VOManager : MonoBehaviour
{
    private float fadeInTime = 15f;
    private float fadeOutTime = 4f;



    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
