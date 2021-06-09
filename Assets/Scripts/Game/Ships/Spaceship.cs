
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    // Basic ship variables
    public ShipStats shipStats;

    public bool alive;

    public BulletController bulletController;
    public RectTransform HPBarObj;
    public GameObject HPCanvas;

    public Sprite[] sprites;
    public ParticleSystem particleSystem;

    // Upgrading system for hp, armor, bullet damage, velocity and rotation speed
    public void CreateShip(ShipStats shipStats)
    {
        this.shipStats = shipStats;
    }

    public void Move(bool moving)
    {
        if (moving)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * shipStats.velocity;
        } else
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * 0;
        }
    }

    public void Rotate(Direction direction)
    {
        if (direction == Direction.Left)
        {
            GetComponent<Rigidbody2D>().angularVelocity = shipStats.torque;
        }
        else if (direction == Direction.Right)
        {
            GetComponent<Rigidbody2D>().angularVelocity = -shipStats.torque;
        } else
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }

    public void Shoot(bool shot)
    {
        if (shot)
        {
            bulletController.ShootBullet(transform.position, transform.rotation, shipStats);
        }
    }

    

    

}
