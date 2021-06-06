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
    public Text hpBarText;
    public RectTransform armorBar;
    public Text armorBarText;

    private void Awake()
    {
        CreateShip(new ShipStats(GAME_CONFIG.playerShipSettings));
        bulletController = GameObject.Find("Main Camera").GetComponentInChildren<BulletController>();
        UpdateUI();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.gameObject.GetComponentInChildren<Bullet>().type != shipStats.bulletType)
            {
                shipStats.TakeDamage(other.gameObject.GetComponentInChildren<Bullet>().bulletDamage);

                if (shipStats.HP <= 0)
                {
                    // Invulnerable right now
                }
            }
        } else if (other.CompareTag("PowerUp"))
        {
            other.gameObject.GetComponentInChildren<PowerUp>().PowerUpFunction(shipStats);
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        hpBar.sizeDelta = new Vector2((shipStats.HP / shipStats.maxHP) * 300f, hpBar.sizeDelta.y);
        armorBar.sizeDelta = new Vector2((shipStats.armor / shipStats.maxArmor) * 300f, armorBar.sizeDelta.y);
        hpBarText.text = shipStats.HP + "";
        armorBarText.text = shipStats.armor + "";
    }

    public void IncrementScore(float score)
    {
        scoreInt += score;
        this.score.text = scoreInt + "";
    }
}
