using System.Collections;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public PowerUpType PowerUpType;

    public float duration;

    public bool alive;

    public void Activate(Vector3 spawnPos, PowerUpType powerUpType)
    {
        gameObject.SetActive(true);
        alive = true;
        this.PowerUpType = powerUpType;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        alive = false;
    }

    public void PowerUpFunction(ShipStats shipStats)
    {
        if (this.PowerUpType == PowerUpType.Repair)
        {
            shipStats.Repair();
        } else if (this.PowerUpType == PowerUpType.Armor)
        {
            shipStats.Replenish();
        }
    }

    public void Type()
    {

    }
}
