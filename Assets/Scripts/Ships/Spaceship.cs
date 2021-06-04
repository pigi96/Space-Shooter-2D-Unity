
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    // Spaceship config -> can be changed by player or enemy, otherwise default values
    private float maxSpeed = 5f;
    private float currentSpeed = 3f;
    private float accelerationSpeed = 0.1f;
    private float rotationSpeed = 120;

    public BulletController bulletController;

    public Spaceship(float maxSpeed, float currentSpeed, float accelerationSpeed, float rotationSpeed)
    {
        this.maxSpeed = maxSpeed;
        this.currentSpeed = currentSpeed;
        this.accelerationSpeed = accelerationSpeed;
        this.rotationSpeed = rotationSpeed;
    }

    public Spaceship() { }

    public void Move(bool moving)
    {
        if (moving)
        {
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
        }
    }

    public void Rotate(Direction direction)
    {
        if (direction == Direction.Left)
        {
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
        }
        else if (direction == Direction.Right)
        {
            transform.Rotate(0, 0, Time.deltaTime * -rotationSpeed);
        }
    }

    public void Shoot(bool shot)
    {
        if (shot)
        {
            bulletController.ShootBullet(transform);
        }
    }
}
