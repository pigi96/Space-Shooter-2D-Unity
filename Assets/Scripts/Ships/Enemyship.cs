using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemyship : Spaceship
{
    public NavMeshAgent agent;

    private Transform player;

    private void Awake()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public Enemyship()
    {
        this.bulletType = BulletType.Enemy;
    }

    float shootTime = 1;
    float currentTime = 0;
    // Move later to GameController for more efficiency
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        agent.SetDestination(player.transform.position);


        currentTime += Time.deltaTime;
        if (currentTime >= shootTime)
        {
            ShootInDirection();
            currentTime = 0;
        }
    }


    public void ShootInDirection()
    {
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        bulletController.ShootBullet(transform.position, rotation, bulletType);
    }
}
