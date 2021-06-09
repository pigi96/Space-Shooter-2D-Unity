using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Direction
{
    None = 0,
    Left = 1,
    Right = 2,
}

public enum BulletType
{
    Enemy = 0,
    Player = 1,
}

public enum PowerUpType
{
    Repair = 0,
    Armor = 1,
    Speed = 3,
    Damage = 4,
}

public enum PlayershipStat
{
    HP,
    Armor,
    Speed,
    Damage,
}

public enum PlayerStats
{
    Money,
    CurrentLevel,
}

public static class Enums
{
    public static Dictionary<PlayershipStat, string> playershipStats = new Dictionary<PlayershipStat, string>();
    public static Dictionary<PlayershipStat, string> playershipStatsCosts = new Dictionary<PlayershipStat, string>();
    public static Dictionary<PlayerStats, string> playerStats = new Dictionary<PlayerStats, string>();

    static Enums()
    {
        foreach (PlayershipStat i in Enum.GetValues(typeof(PlayershipStat)))
        {
            playershipStats.Add(i, i.ToString());
            playershipStatsCosts.Add(i, i+"_cost");
        }

        playerStats.Add(PlayerStats.Money, PlayerStats.Money.ToString());
        playerStats.Add(PlayerStats.CurrentLevel, PlayerStats.CurrentLevel.ToString());
    }
}