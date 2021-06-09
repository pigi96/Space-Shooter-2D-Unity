using System.Collections;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public Sprite health, armor, speed, damage;

    public float duration;

    public bool alive;
    public bool pickedUp;

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

        
        transform.position = spawnPos;
        StartCoroutine(AnimateIn());
    }

    public void Deactivate()
    {
        StartCoroutine(AnimateOut());
    }

    IEnumerator AnimateOut()
    {
        pickedUp = true;
        SoundController.instance.PoweUp();

        while (transform.localScale.x > 0)
        {
            transform.Rotate(0, 0, transform.rotation.z + Time.deltaTime * 300);
            transform.localScale = new Vector3(transform.localScale.x - 0.08f, transform.localScale.y - 0.08f);
            yield return null;
        }

        gameObject.SetActive(false);
        alive = false;
    }

    IEnumerator AnimateIn()
    {
        pickedUp = false;
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0, 0);

        float sizeScale = 0;
        while (sizeScale <= 25)
        {
            if (pickedUp) break;
            sizeScale += Time.deltaTime * 12.5f;
            transform.Rotate(0, 0, 540f*Time.deltaTime);
            transform.localScale = new Vector3(sizeScale, sizeScale);
            yield return null;
        }
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
