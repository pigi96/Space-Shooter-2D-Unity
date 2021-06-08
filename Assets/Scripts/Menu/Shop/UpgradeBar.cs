using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBar : MonoBehaviour
{
    public Text valueText, costText;

    public PlayershipStat playershipStat;

    private void Awake()
    {
        UpdateUI();
    }

    public void UpgradeClicked()
    {
        UpgradeLogic.UpgradeStat(playershipStat);
        UpdateUI();
    }

    private void UpdateUI()
    {
        valueText.text = PlayerPrefs.GetFloat(Enums.playershipStats[playershipStat]).ToString();
        costText.text = PlayerPrefs.GetFloat(Enums.playershipStatsCosts[playershipStat]).ToString();

        // Update money sum
        GameObject.Find("Money").GetComponentInChildren<Text>().text = PlayerPrefs.GetFloat(Enums.playerStats[PlayerStats.Money]).ToString();
    }
}
