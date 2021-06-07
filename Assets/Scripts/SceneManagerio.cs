using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerio : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeToGameField()
    {
        SceneManager.LoadScene(1);
    }

    public static void ChangeToMainMenuStatic()
    {
        SceneManager.LoadScene(0);
    }

    public static void ChangeToGameFieldStatic()
    {
        SceneManager.LoadScene(1);
    }
}
