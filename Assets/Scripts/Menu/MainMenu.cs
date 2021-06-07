using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int currentLevel = PlayerPrefs.GetInt("Current_Level", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
