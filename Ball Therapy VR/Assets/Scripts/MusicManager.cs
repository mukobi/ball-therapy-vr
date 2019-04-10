using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private float fadeInTime = 15f;
    private float fadeOutTime = 6f;

    void Start()
    {
        StartCoroutine(FadeIn(GetComponent<AudioSource>(), fadeInTime));
    }

    public void StopMusic()
    {
        //Debug.Log("Stopping Music");
        StartCoroutine(FadeOut(GetComponent<AudioSource>(), fadeOutTime));
    }

    private static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            //Debug.Log(audioSource.volume);
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
    private static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.volume = 0f;
        audioSource.Play();
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
