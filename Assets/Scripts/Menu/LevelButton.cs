using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int level { get; set; }

    public void OnClick()
    {
        GAME_CONFIG.LEVEL = level;
        LevelGeneration.CreateShipStatsForLevel(GAME_CONFIG.LEVEL);
        SceneManager.LoadScene(1);
    }
}
