using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemyship : Spaceship
{
    public NavMeshAgent agent;

    private Transform player;

    private void Awake()
    {
        CreateShip(new ShipStats(GAME_CONFIG.enemiesShipSettings));
        bulletController = GameObject.Find("Main Camera").GetComponentInChildren<BulletController>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    float shootTime = 1;
    float currentTime = 0;
    // Move later to GameController for more efficiency
    public void AI()
    {
        if (player == null)
        {
            try
            {
                player = GameObject.Find("Player").transform;    
            }
            catch (Exception err)
            {
                // Dead player -> Should not happen anyway, test only
                return;
            }
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

        bulletController.ShootBullet(transform.position, rotation, shipStats.bulletType, shipStats.bulletDamage);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.gameObject.GetComponentInChildren<Bullet>().type != shipStats.bulletType)
            {
                shipStats.TakeDamage(other.gameObject.GetComponentInChildren<Bullet>().bulletDamage);
                HPBarObj.sizeDelta = new Vector2((shipStats.HP / shipStats.maxHP) * 300f, HPBarObj.sizeDelta.y);

                if (shipStats.HP <= 0)
                {
                    player.gameObject.GetComponentInChildren<Playership>().IncrementScore(shipStats.maxHP);
                    Deactivate();
                }
            }
        }
    }

}
