using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Script has to go on the same object as GameControler.cs
public class GameUIController : MonoBehaviour
{
    public GameObject UI;

    public GameObject pauseMenuUI;
    
    public GameObject gameOverUI;
    public Text gameOverScore, gameOverMsg, nextButtonMsg;

    public void OpenPauseMenu()
    {
        gameObject.GetComponentInChildren<GameController>().Pause();
        pauseMenuUI.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        gameObject.GetComponentInChildren<GameController>().Resume();
        pauseMenuUI.SetActive(false);
    }

    public void GameOver(bool success, float score)
    {
        gameOverUI.SetActive(true);

        if (success)
        {
            gameOverMsg.text = "Completed!";
            nextButtonMsg.text = "Next";
        } else
        {
            gameOverMsg.text = "Failed!";
            nextButtonMsg.text = "Repeat";
        }

        gameOverScore.text = score.ToString();
    }

    public void NextARepeatButton() 
    {
        int newLevel = GAME_CONFIG.LEVEL;
        if (gameObject.GetComponentInChildren<GameController>().success)
            GAME_CONFIG.LEVEL = newLevel + 1;
        LevelGeneration.CreateShipStatsForLevel(GAME_CONFIG.LEVEL);
        GameObject.Find("LevelLoader").GetComponentInChildren<LevelLoader>().LoadNextLevel(1);
    }
}
