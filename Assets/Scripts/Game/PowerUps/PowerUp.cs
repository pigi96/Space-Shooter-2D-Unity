using System.Collections;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;

    public float duration;

    public bool alive;

    public void Activate(Vector3 spawnPos, PowerUpType powerUpType)
    {
        gameObject.SetActive(true);
        alive = true;
        this.powerUpType = PowerUpType.Armor;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        alive = false;
    }

    public void PowerUpFunction(ShipStats shipStats)
    {
        if (this.powerUpType == PowerUpType.Repair)
        {
            shipStats.Repair();
        } else if (this.powerUpType == PowerUpType.Armor)
        {
            shipStats.Replenish();
        } else if (this.powerUpType == PowerUpType.Speed)
        {
            shipStats.DoubleSpeed();
        } else if (this.powerUpType == PowerUpType.Damage)
        {
            shipStats.DoubleDamage();
        }
    }

    public void Type()
    {

    }
}
