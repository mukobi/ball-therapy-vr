using System.Collections;
using UnityEngine;

public class VOManager : MonoBehaviour
{
    public AudioClip startClip;
    public AudioClip endClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(startClip != null)
        {
            audioSource.Stop();
            audioSource.clip = startClip;
            audioSource.Play();
        }
    }

    public void PlayEndClip()
    {
        if (endClip != null)
        {
            audioSource.Stop();
            audioSource.clip = endClip;
            audioSource.Play();
        }
    }
}
