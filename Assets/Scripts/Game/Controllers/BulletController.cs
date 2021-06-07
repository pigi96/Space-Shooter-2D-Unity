﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public List<Bullet> bullets = new List<Bullet>();

    public void ShootBullet(Vector3 startPos, Quaternion rotation, ShipStats shipStats)
    {
        bool reusedBullet = false;
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].alive)
            {
                reusedBullet = true;
                bullets[i].Activate(startPos, rotation, shipStats);
                break;
            }
        }

        if (!reusedBullet)
        {
            GameObject newBullet = Instantiate(bulletPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newBullet.transform.parent = GameObject.Find("Bullets").transform;
            newBullet.GetComponentInChildren<Bullet>().Activate(startPos, rotation, shipStats);
            bullets.Add(newBullet.GetComponentInChildren<Bullet>());
        }
    }

    public void Update()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i].alive)
            {
                bullets[i].transform.Translate(Vector3.up * bullets[i].gameObject.GetComponentInChildren<Bullet>().shipStats.velocity * 3 * Time.deltaTime);

                //bullets[i].currentDistance += bullets[i].gameObject.GetComponentInChildren<Bullet>().shipStats.velocity * 3 * Time.deltaTime;
                bullets[i].timeAlive += Time.deltaTime;

                if (bullets[i].timeAlive > GAME_CONFIG.BULLET_TIME_ALIVE)
                {
                    bullets[i].Deactivate();
                }
            }
        }
    }
}