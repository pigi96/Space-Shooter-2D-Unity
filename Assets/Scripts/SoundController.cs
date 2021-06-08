using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioSource audioSourceSound;
    public AudioSource audioSourceMusic;

    public AudioClip UIClickClip, successClip, failedClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(transform.gameObject);
        }
    }

    public void UIClick()
    {
        audioSourceSound.PlayOneShot(UIClickClip, 1f);
    }

    public void SuccessSound()
    {
        audioSourceSound.PlayOneShot(successClip, 1f);
    }

    public void FailedSound()
    {
        audioSourceSound.PlayOneShot(failedClip, 1f);
    }
}
