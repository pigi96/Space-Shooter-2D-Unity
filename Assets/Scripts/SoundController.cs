using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioSource audioSourceSound;
    public AudioSource audioSourceMusic;

    public AudioClip UIClickClip, successClip, failedClip, laser1Clip, laser2Clip, laser3Clip, explosionClip, powerUpClip,
        gameOverClip, gameCompleteClip, openUpClip;

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
        audioSourceSound.PlayOneShot(UIClickClip, 0.5f);
    }

    public void SuccessSound()
    {
        audioSourceSound.PlayOneShot(successClip, 0.3f);
    }

    public void FailedSound()
    {
        audioSourceSound.PlayOneShot(failedClip, 0.3f);
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

    public void GameOver()
    {
        audioSourceSound.PlayOneShot(gameOverClip, 0.3f);
    }
    
    public void GameComplete()
    {
        audioSourceSound.PlayOneShot(gameCompleteClip, 0.3f);
    }

    public void OpenLevel()
    {
        audioSourceSound.PlayOneShot(openUpClip, 0.02f);
    }
}
