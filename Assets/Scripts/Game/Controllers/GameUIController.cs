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
    public GameObject successObj, failureObj;

    public GameObject changableButton;
    public Sprite successSprite, failureSprite;

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
            successObj.SetActive(true);
            failureObj.SetActive(false);
            changableButton.GetComponentInChildren<Image>().sprite = successSprite;
        } else
        {
            successObj.SetActive(false);
            failureObj.SetActive(true);
            changableButton.GetComponentInChildren<Image>().sprite = failureSprite;
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
