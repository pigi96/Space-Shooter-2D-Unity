using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletType type;
    public ShipStats shipStats;
    public float bulletDamage;

    public bool alive = false;

    //public float currentDistance = 0;
    public float timeAlive = 0;

    public Sprite singleBullet, doubleBullet;

    public void Deactivate()
    {
        alive = false;
        //currentDistance = 0;
        timeAlive = 0;
        gameObject.SetActive(false);
    }

    public void Activate(Vector3 startPos, Quaternion rotation, ShipStats shipStats)
    {
        alive = true;
        this.type = shipStats.bulletType;
        gameObject.SetActive(true);
        this.type = shipStats.bulletType;
        transform.position = startPos;
        transform.rotation = rotation;
        this.bulletDamage = shipStats.bulletDamage;
        this.shipStats = shipStats;

        if (shipStats.doubleDamage <= 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = singleBullet;
        } else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = doubleBullet;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            return;
        }

        if (type == BulletType.Enemy && other.CompareTag("Enemy"))
        {
            return;
        }

        if (type == BulletType.Player && other.CompareTag("Player"))
        {
            return;
        }

        Deactivate();
    }
}