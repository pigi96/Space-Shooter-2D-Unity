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

    public ParticleSystem alivePart, deadPart;

    private float hpBarWidth, armorBarWidth;
    private void Awake()
    {
        hpBarWidth = hpBar.GetComponentInChildren<RectTransform>().sizeDelta.x;
        armorBarWidth = armorBar.GetComponentInChildren<RectTransform>().sizeDelta.x;
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
                    gameObject.GetComponentInChildren<Transform>().localScale = new Vector3(0, 0, 0);
                    alivePart.Stop();
                    deadPart.Play();
                    GameObject.Find("Main Camera").GetComponentInChildren<GameController>().GameOver();
                }
            }
        } else if (other.CompareTag("PowerUp"))
        {
            PowerUpPickedUp(other.gameObject);
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        hpBar.sizeDelta = new Vector2((shipStats.HP / shipStats.maxHP) * hpBarWidth, hpBar.sizeDelta.y);
        armorBar.sizeDelta = new Vector2((shipStats.armor / shipStats.maxArmor) * armorBarWidth, armorBar.sizeDelta.y);
        hpBarText.text = shipStats.HP + "";
        armorBarText.text = shipStats.armor + "";
    }

    void PowerUpPickedUp(GameObject powerUp)
    {
        powerUp.gameObject.GetComponentInChildren<PowerUp>().PowerUpFunction(shipStats);
        powerUp.gameObject.GetComponentInChildren<PowerUp>().Deactivate();
    }

    public void IncrementScore(float score)
    {
        scoreInt += score;
        this.score.text = scoreInt + "";
    }
}
