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

    // Move later to GameController for more efficiency
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        agent.SetDestination(player.transform.position);
    }
}
