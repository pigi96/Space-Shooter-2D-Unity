using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemyship : Spaceship
{
    public NavMeshAgent agent;

    private Transform player;

    Vector2 saveVelocity;
    float saveAngularVelocity;

    Vector3 savePos;
    private void Awake()
    {
        CreateShip(new ShipStats(GAME_CONFIG.enemiesShipSettings));
        bulletController = GameObject.Find("Main Camera").GetComponentInChildren<BulletController>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        /*player = GameObject.Find("Player").transform;
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(player.transform.position, path);
        agent.SetPath(path);*/
    }

    float currentTime = 0;
    float pathfind = 0;
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

        pathfind -= Time.deltaTime;
        if (pathfind <= 0)
        {
            agent.SetDestination(player.transform.position);
            pathfind = 0.3f;
        }

        currentTime += Time.deltaTime;
        if (currentTime >= LevelConfiguration.enemiesShootingSpeed)
        {
            ShootInDirection();
        }
    }

    NavMeshPath path;
    void NavMeshPath()
    {
        //path = new NavMeshPath();
        //print(NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path));
        agent.SetDestination(player.transform.position);
        agent.isStopped = true;
        string var = "";
        for (int i = 0; i < agent.path.corners.Length; i++)
        {
            var += agent.path.corners[i] + " , ";
        }
        print(var);
        Move(true);
        Vector3 heading = agent.path.corners[1] - transform.position;
        Direction rotateTo = AngleDir(transform.forward, heading, transform.up);
        Rotate(rotateTo);
    }

    //returns -1 when to the left, 1 to the right, and 0 for forward/backward
    Direction AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0.1f)
        {
            return Direction.Right;
        }
        else if (dir < -0.1f)
        {
            return Direction.Left;
        }
        else
        {
            return Direction.None;
        }
    }

    public void Pause()
    {
        agent.isStopped = true;
        agent.SetDestination(transform.position);
        //Rigidbody2D rigidbody2D = gameObject.GetComponentInChildren<Rigidbody2D>();
        //saveVelocity = rigidbody2D.velocity;
        //saveAngularVelocity = rigidbody2D.angularVelocity;
        //rigidbody2D.velocity = new Vector2(0, 0);
        //rigidbody2D.angularVelocity = 0;
        //rigidbody2D.isKinematic = true;
    }

    public void Resume()
    {
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
        //Rigidbody2D rigidbody2D = gameObject.GetComponentInChildren<Rigidbody2D>();
        //rigidbody2D.isKinematic = false;
        //rigidbody2D.velocity = saveVelocity;
        //rigidbody2D.angularVelocity = saveAngularVelocity;
    }

    public void ShootInDirection()
    {
        // Only shoot if the bullet can hit the target at the moment of shooting
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance >= shipStats.velocity * 3 * GAME_CONFIG.BULLET_TIME_ALIVE) return;

        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        bulletController.ShootBullet(transform.position, rotation, shipStats);

        currentTime = 0;
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
                    GameObject.Find("Main Camera").GetComponentInChildren<GameController>().EnemyKilled();
                    gameObject.transform.parent.GetComponent<EnemyBrain>().Deactivate();
                }
            }
        }
    }

    


   

}
