using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Playership playershipScr;
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
        ControlEnemies();
    }


    void ControlPlayer()
    {
        playershipScr.Move(PlayerMoveInput());
        playershipScr.Rotate(PlayerRotateInput());
        playershipScr.Shoot(PlayerHasShot());
        transform.position = new Vector3(playershipScr.transform.position.x, playershipScr.transform.position.y, -10);
    }

    float spawnTimer = 0;
    void ControlEnemies()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > GAME_CONFIG.spawn_timer) {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    // Use total random and let physics push it out + spawn outside camera field view
    void SpawnEnemy()
    {
        float playerX = playershipScr.transform.position.x;
        float playerY = playershipScr.transform.position.y;

        float spawnX, spawnY;
        do
        {
            spawnX = -GAME_CONFIG.DEFAULT_WIDTH / 2 + Random.Range(0, GAME_CONFIG.DEFAULT_WIDTH - 10);
            spawnY = -GAME_CONFIG.DEFAULT_HEIGHT / 2 + Random.Range(0, GAME_CONFIG.DEFAULT_HEIGHT - 10);
        } while (Mathf.Abs(playerX - spawnX) <= 100 || Mathf.Abs(playerY - spawnY) <= 50);

        enemyController.SpawnEnemy(new Vector3(spawnX, spawnY, 0));
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
