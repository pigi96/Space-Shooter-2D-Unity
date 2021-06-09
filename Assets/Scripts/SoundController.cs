using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioSource audioSourceSound;
    public AudioSource audioSourceMusic;

    public AudioClip UIClickClip, successClip, failedClip, laser1Clip, laser2Clip, laser3Clip, explosionClip, powerUpClip;

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

    public void LaserClip()
    {
        audioSourceSound.PlayOneShot(laser1Clip, 0.07f);
    }

    public void Laser2Clip()
    {
        audioSourceSound.PlayOneShot(laser2Clip, 0.05f);
    }

    public void Laser3Clip()
    {
        audioSourceSound.PlayOneShot(laser3Clip, 0.20f);
    }

    public void Explosion()
    {
        audioSourceSound.PlayOneShot(explosionClip, 0.11f);
    }

    public void PoweUp()
    {
        audioSourceSound.PlayOneShot(powerUpClip, 0.20f);
    }
}
