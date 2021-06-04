
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float MAX_HP = 100;
    public float HP = 100;

    // Spaceship config -> can be changed by player or enemy, otherwise default values
    private float maxSpeed = 5f;
    private float currentSpeed = 50f;
    private float accelerationSpeed = 0.1f;
    private float rotationSpeed = 120;
    private float torqueSpeed = 9999f;

    public BulletController bulletController;
    public BulletType bulletType;
    public RectTransform HPBarObj;

    public Spaceship(float maxSpeed, float currentSpeed, float accelerationSpeed, float rotationSpeed, BulletType bulletType)
    {
        this.maxSpeed = maxSpeed;
        this.currentSpeed = currentSpeed;
        this.accelerationSpeed = accelerationSpeed;
        this.rotationSpeed = rotationSpeed;
        this.bulletType = bulletType;
    }

    public Spaceship(BulletType bulletType) 
    {
        this.bulletType = bulletType;
    }

    public Spaceship()
    {

    }

    public void Move(bool moving)
    {
        if (moving)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * 33f;
        } else
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * 0;
        }
    }

    public void Rotate(Direction direction)
    {
        if (direction == Direction.Left)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().AddTorque(torqueSpeed);
        }
        else if (direction == Direction.Right)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().AddTorque(-torqueSpeed);
        } else
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }

    public void Shoot(bool shot)
    {
        if (shot)
        {
            bulletController.ShootBullet(transform, bulletType);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.gameObject.GetComponentInChildren<Bullet>().type != this.bulletType)
            {
                HP -= 20;
                HPBarObj.sizeDelta = new Vector2((HP/MAX_HP) * 300f, HPBarObj.sizeDelta.y);
            }
        }
    }
}
