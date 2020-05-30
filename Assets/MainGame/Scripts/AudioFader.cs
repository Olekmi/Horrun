using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioFader
{
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 0;

    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.volume = 0.01f;
        audioSource.Play();


        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1;

    }
}
