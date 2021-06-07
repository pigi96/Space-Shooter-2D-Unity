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
        int currentLevel = PlayerPrefs.GetInt("Current_Level", 0);
        currentLevel = 30;

        for (int i = 0; i < currentLevel; i++)
        {
            GameObject newLevelButton = Instantiate(levelPrefab);
            newLevelButton.GetComponentInChildren<LevelButton>().level = i + 1;
            newLevelButton.GetComponentInChildren<Text>().text = i + 1 + "";
            newLevelButton.transform.SetParent(content.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
