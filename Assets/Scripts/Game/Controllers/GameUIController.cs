using System.Collections;
using UnityEngine;


public class GameUIController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void OpenPauseMenu()
    {
        GameObject.Find("Main Camera").GetComponentInChildren<GameController>().Pause();
        pauseMenuUI.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        GameObject.Find("Main Camera").GetComponentInChildren<GameController>().Resume();
        pauseMenuUI.SetActive(false);
    }
}
