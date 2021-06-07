using System.Collections;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public Sprite health, armor, speed, damage;

    public float duration;

    public bool alive;

    public void Activate(Vector3 spawnPos, PowerUpType powerUpType)
    {
        gameObject.SetActive(true);
        alive = true;
        this.powerUpType = powerUpType;

        if (powerUpType == PowerUpType.Repair)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = health;
        } 
        else if (powerUpType == PowerUpType.Armor)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = armor;
        }
        else if (powerUpType == PowerUpType.Damage)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = damage;
        }
        else if (powerUpType == PowerUpType.Speed)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = speed;
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        alive = false;
    }

    public void PowerUpFunction(ShipStats shipStats)
    {
        if (powerUpType == PowerUpType.Repair)
        {
            shipStats.Repair();
        } else if (powerUpType == PowerUpType.Armor)
        {
            shipStats.Replenish();
        } else if (powerUpType == PowerUpType.Speed)
        {
            shipStats.DoubleSpeed();
        } else if (powerUpType == PowerUpType.Damage)
        {
            shipStats.DoubleDamage();
        }
    }
}
