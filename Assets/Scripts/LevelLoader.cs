using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadNextLevel(int buildIndex)
    {
        StartCoroutine(LoadLevel(buildIndex));
    }

    IEnumerator LoadLevel(int buildIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(buildIndex);
    }
}
