using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For inspector purposes
public class SoundLoader : MonoBehaviour
{
    private SoundController soundController;
    private void Start()
    {
        soundController = GameObject.Find("SoundController").GetComponentInChildren<SoundController>();
    }

    public void UIClick()
    {
        soundController.UIClick();
    }
}
