using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject levelPrefab;
    public GameObject content;

    static bool firstOpened = false;
    // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.SetInt("FIRST_START", 0);
        //PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("FIRST_START", 0) == 0)
        {
            GAME_CONFIG.InitStats();
        }

        if (!firstOpened && GAME_CONFIG.forceOverwriteDataAtGameStart)
        {
            firstOpened = true;
            GAME_CONFIG.InitStats();
        }

        int currentLevel = PlayerPrefs.GetInt(Enums.playerStats[PlayerStats.CurrentLevel], 0);
        for (int i = 0; i < currentLevel; i++)
        {
            GameObject newLevelButton = Instantiate(levelPrefab);
            newLevelButton.GetComponentInChildren<LevelButton>().level = i + 1;
            newLevelButton.GetComponentInChildren<Text>().text = i + 1 + "";
            newLevelButton.transform.SetParent(content.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
