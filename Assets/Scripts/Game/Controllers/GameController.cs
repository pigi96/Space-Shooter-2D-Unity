using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Playership playershipScr;
    public EnemyController enemyController;
    public PowerUpController powerUpController;
    public Scrolling scrolling;
    public BulletController bulletController;

    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            ControlPlayer();
            ControlEnemies();
            ControlPowerUps();
            ControlBullets();
        }
    }


    void ControlPlayer()
    {
        playershipScr.shipStats.Update(Time.deltaTime);
        playershipScr.Move(PlayerMoveInput());
        playershipScr.Rotate(PlayerRotateInput());
        playershipScr.Shoot(PlayerHasShot());
        transform.position = new Vector3(playershipScr.transform.position.x, playershipScr.transform.position.y, -10); // Camera update
        scrolling.UpdatePosition(playershipScr.transform);
    }

    void ControlBullets()
    {
        bulletController.UpdateBullets();
    }

    float enemiesSpawnTimer = 0;
    void ControlEnemies()
    {
        enemiesSpawnTimer += Time.deltaTime;
        if (enemiesSpawnTimer > LevelConfiguration.enemiesSpawnTimer) {
            SpawnEnemy();
            enemiesSpawnTimer = 0;
        }

        enemyController.UpdateEnemies();
    }

    public void Pause()
    {
        pause = true;
        playershipScr.Move(false);
        playershipScr.Rotate(Direction.None);
        enemyController.Pause();
    }

    public void Resume()
    {
        pause = false;
        enemyController.Resume();
    }

    public void StopPlayer()
    {
        
    }

    // Use total random and let physics push it out + spawn outside camera field view
    void SpawnEnemy()
    {
        float playerX = playershipScr.transform.position.x;
        float playerY = playershipScr.transform.position.y;

        float spawnX, spawnY;
        int maxTry = 33;
        do
        {
            maxTry--;
            spawnX = -LevelConfiguration.playfieldWidth / 2 + 10 + Random.Range(0, LevelConfiguration.playfieldWidth - 20);
            spawnY = -LevelConfiguration.playfieldHeight / 2 + 10 + Random.Range(0, LevelConfiguration.playfieldHeight - 20);
        } while ((Mathf.Abs(playerX - spawnX) <= 100 || Mathf.Abs(playerY - spawnY) <= 50) && maxTry >= 0);

        enemyController.SpawnEnemy(new Vector3(spawnX, spawnY, 0));
    }

    float powerUpSpawnTimer = 0;
    void ControlPowerUps()
    {
        powerUpSpawnTimer += Time.deltaTime;
        if (powerUpSpawnTimer > LevelConfiguration.powerUpSpawnTimer)
        {
            SpawnPowerUp();
            powerUpSpawnTimer = 0;
        }
    }

    void SpawnPowerUp()
    {
        float spawnX, spawnY;
        int maxTry = 33;
        do
        {
            maxTry--;
            spawnX = -LevelConfiguration.playfieldWidth / 2 + Random.Range(0, LevelConfiguration.playfieldWidth - 10);
            spawnY = -LevelConfiguration.playfieldHeight / 2 + Random.Range(0, LevelConfiguration.playfieldHeight - 10);
            Collider2D[] obstaclesCollided = Physics2D.OverlapBoxAll(new Vector3(spawnX, spawnY, 0), new Vector3(6f, 5.11f, 1), 0);
            if (obstaclesCollided.Length == 0) break;
        } while (maxTry > 0);

        powerUpController.SpawnPowerUp(new Vector3(spawnX, spawnY, 0));
    }


    public bool PlayerMoveInput()
    {
        return Input.GetKey(KeyCode.UpArrow) ? true : false;
    }

    public Direction PlayerRotateInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return Direction.Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return Direction.Right;
        }
        return Direction.None;
    }

    public bool PlayerHasShot()
    {
        return Input.GetKeyDown(KeyCode.Space) ? true : false;
    }
}
