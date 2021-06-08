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

    // Custom algorithms for everything :/ TODO
    private static float UpgradeHP(float value)
    {
        return value + 2;
    }

    private static float UpgradeHPCost(float cost)
    {
        return cost + 2;
    }

    private static float UpgradeArmor(float value)
    {
        return value + 2;
    }

    private static float UpgradeArmorCost(float cost)
    {
        return cost + 2;
    }

    private static float UpgradeSpeed(float value)
    {
        return value + 2;
    }

    private static float UpgradeSpeedCost(float cost)
    {
        return cost + 2;
    }

    private static float UpgradeDamage(float value)
    {
        return value + 2;
    }

    private static float UpgradeDamageCost(float cost)
    {
        return cost + 2;
    }
}
