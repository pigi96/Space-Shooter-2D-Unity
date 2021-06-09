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

    public GameObject nextLevelButton;

    public void OpenPauseMenu()
    {
        gameObject.GetComponentInChildren<GameController>().Pause();
        pauseMenuUI.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        StartCoroutine(ClosePauseMenuAnimated());
    }

    IEnumerator ClosePauseMenuAnimated()
    {
        pauseMenuUI.GetComponentInChildren<Animator>().SetTrigger("Start");
        gameObject.GetComponentInChildren<GameController>().Resume();
        yield return new WaitForSeconds(1f);
        pauseMenuUI.SetActive(false);
    }

    public void GameOver(bool success, float score)
    {
        gameOverUI.SetActive(true);

        if (success)
        {
            SoundController.instance.GameComplete();
            successObj.SetActive(true);
            failureObj.SetActive(false);
            nextLevelButton.SetActive(true);
        } else
        {
            SoundController.instance.GameOver();
            successObj.SetActive(false);
            failureObj.SetActive(true);
            nextLevelButton.SetActive(false);
        }

        gameOverScore.text = score.ToString();
    }

    public void NextLevel() 
    {
        int newLevel = GAME_CONFIG.LEVEL;
        GAME_CONFIG.LEVEL = newLevel + 1;
        LevelGeneration.CreateShipStatsForLevel(GAME_CONFIG.LEVEL);
        GameObject.Find("LevelLoader").GetComponentInChildren<LevelLoader>().LoadNextLevel(1);
    }

    public void RepeatLevel()
    {
        int newLevel = GAME_CONFIG.LEVEL;
        LevelGeneration.CreateShipStatsForLevel(GAME_CONFIG.LEVEL);
        GameObject.Find("LevelLoader").GetComponentInChildren<LevelLoader>().LoadNextLevel(1);
    }
}
