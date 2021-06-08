using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject levelPrefab;
    public GameObject content;

    // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.SetInt("FIRST_START", 0);
        //PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("FIRST_START", 0) == 0)
        {
            InitStats();
        }

        int currentLevel = PlayerPrefs.GetInt("Current_Level", 0);
        currentLevel = 30;

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

    void InitStats()
    {
        PlayerPrefs.SetFloat(Enums.playershipStats[PlayershipStat.HP], 20);
        PlayerPrefs.SetFloat(Enums.playershipStatsCosts[PlayershipStat.HP], 10);

        PlayerPrefs.SetFloat(Enums.playershipStats[PlayershipStat.Armor], 10);
        PlayerPrefs.SetFloat(Enums.playershipStatsCosts[PlayershipStat.Armor], 10);

        PlayerPrefs.SetFloat(Enums.playershipStats[PlayershipStat.Speed], 33);
        PlayerPrefs.SetFloat(Enums.playershipStatsCosts[PlayershipStat.Speed], 10);

        PlayerPrefs.SetFloat(Enums.playershipStats[PlayershipStat.Damage], 1);
        PlayerPrefs.SetFloat(Enums.playershipStatsCosts[PlayershipStat.Damage], 10);

        PlayerPrefs.SetFloat(Enums.playerStats[PlayerStats.Money], 1000);

        PlayerPrefs.SetInt("FIRST_START", 1);
        PlayerPrefs.Save();
    }
}
