using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<Enemyship> enemies = new List<Enemyship>();

    public void SpawnEnemy(Vector3 startPos)
    {
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
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].alive)
            {
                enemies[i].AI();
            }
        }
    }
}
