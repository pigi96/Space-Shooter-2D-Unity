using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playership : Spaceship
{
    public float scoreInt;
    public Text score;
    public RectTransform hpBar;

    private void Awake()
    {
        CreateShip(new ShipStats(GAME_CONFIG.playerShipSettings));
        bulletController = GameObject.Find("Main Camera").GetComponentInChildren<BulletController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.gameObject.GetComponentInChildren<Bullet>().type != shipStats.bulletType)
            {
                shipStats.TakeDamage(other.gameObject.GetComponentInChildren<Bullet>().bulletDamage);
                hpBar.sizeDelta = new Vector2((shipStats.HP / shipStats.maxHP) * 300f, hpBar.sizeDelta.y);

                if (shipStats.HP <= 0)
                {
                    // Invulnerable right now
                }
            }
        } else if (other.CompareTag("PowerUp"))
        {
            other.gameObject.GetComponentInChildren<PowerUp>().PowerUpFunction(shipStats);
            hpBar.sizeDelta = new Vector2((shipStats.HP / shipStats.maxHP) * 300f, hpBar.sizeDelta.y);
        }
    }

    public void IncrementScore(float score)
    {
        scoreInt += score;
        this.score.text = scoreInt + "";
    }
}
