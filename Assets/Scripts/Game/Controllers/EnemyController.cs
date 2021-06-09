using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<EnemyBrain> enemies = new List<EnemyBrain>();
    bool blockSpawning = false;

    public void SpawnEnemy(Vector3 startPos)
    {
        if (blockSpawning) return;



        bool reusedEnemey = false;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].alive)
            {
                reusedEnemey = true;
                enemies[i].Activate(startPos);
                break;
            }
        }

        if (!reusedEnemey)
        {
            GameObject newBullet = Instantiate(enemyPrefab);
            newBullet.GetComponentInChildren<EnemyBrain>().Activate(startPos);
            enemies.Add(newBullet.GetComponentInChildren<EnemyBrain>());
        }
    }

    public void UpdateEnemies()
    {
        int alive = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].alive && !enemies[i].halfAlive)
            {
                alive++;
                enemies[i].enemy.GetComponent<Enemyship>().AI();
            }
        }

        if (alive >= GAME_CONFIG.max_enemies)
            blockSpawning = true;
        else
            blockSpawning = false;
    }

    public void Pause()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].alive && !enemies[i].halfAlive)
            {
                enemies[i].enemy.GetComponent<Enemyship>().Pause();
            }
        }
    }

    public void Resume()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].alive && !enemies[i].halfAlive)
            {
                enemies[i].enemy.GetComponent<Enemyship>().Resume();
            }
        }
    }
}
