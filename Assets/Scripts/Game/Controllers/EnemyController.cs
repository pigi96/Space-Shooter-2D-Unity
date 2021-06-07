using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<Enemyship> enemies = new List<Enemyship>();
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
            newBullet.GetComponentInChildren<Enemyship>().Activate(startPos);
            enemies.Add(newBullet.GetComponentInChildren<Enemyship>());
        }
    }

    public void Update()
    {
        int alive = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].alive)
            {
                alive++;
                enemies[i].AI();
            }
        }

        if (alive >= GAME_CONFIG.max_enemies)
            blockSpawning = true;
        else
            blockSpawning = false;
    }
}
