using UnityEditor;
using UnityEngine;


public static class UpgradeLogic
{
    public static bool UpgradeStat(PlayershipStat stat)
    {
        float money = PlayerPrefs.GetFloat(Enums.playerStats[PlayerStats.Money]);
        float value = PlayerPrefs.GetFloat(Enums.playershipStats[stat]);
        float cost = PlayerPrefs.GetFloat(Enums.playershipStatsCosts[stat]);

        if (money >= cost)
        {
            money -= cost;
            PlayerPrefs.SetFloat(Enums.playerStats[PlayerStats.Money], money);

            if (stat == PlayershipStat.HP)
            {
                value = UpgradeHP(value);
                cost = UpgradeHPCost(cost);
            } else if (stat == PlayershipStat.Armor)
            {
                value = UpgradeArmor(value);
                cost = UpgradeArmorCost(cost);
            } else if (stat == PlayershipStat.Speed)
            {
                value = UpgradeSpeed(value);
                cost = UpgradeSpeedCost(cost);
            } else if (stat == PlayershipStat.Damage)
            {
                value = UpgradeDamage(value);
                cost = UpgradeDamageCost(cost);
            }

            PlayerPrefs.SetFloat(Enums.playershipStats[stat], value);
            PlayerPrefs.SetFloat(Enums.playershipStatsCosts[stat], cost);
            PlayerPrefs.Save();
            return true;
        } else
        {
            return false;
        }
    }

    // TODO -> change to leveling system, not so primitive... :/
    private static float UpgradeHP(float value)
    {
        int newValue = (int)(1.5f * value);
        return newValue;
    }

    private static float UpgradeHPCost(float cost)
    {
        int newCost = (int)(2 * cost);
        return newCost;
    }

    private static float UpgradeArmor(float value)
    {
        int newValue = (int)(1.5f * value);
        return newValue;
    }

    private static float UpgradeArmorCost(float cost)
    {
        int newCost = (int)(2 * cost);
        return newCost;
    }

    private static float UpgradeSpeed(float value)
    {
        int newValue = (int)(value + 3);
        return newValue;
    }

    private static float UpgradeSpeedCost(float cost)
    {
        int newCost = (int)(2 * cost);
        return newCost;
    }

    private static float UpgradeDamage(float value)
    {
        int newValue = (int)(1.5f * value);
        return newValue;
    }

    private static float UpgradeDamageCost(float cost)
    {
        int newCost = (int)(2f * cost);
        return newCost;
    }
}
