using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public List<PowerUp> powerUps = new List<PowerUp>();

    public void SpawnPowerUp(Vector3 startPos)
    {
        Array values = Enum.GetValues(typeof(PowerUpType));
        PowerUpType selectedPower = (PowerUpType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        bool reusedPowerup = false;
        for (int i = 0; i < powerUps.Count; i++)
        {
            if (!powerUps[i].alive)
            {
                reusedPowerup = true;
                powerUps[i].Activate(startPos, selectedPower);
                break;
            }
        }

        if (!reusedPowerup)
        {
            GameObject newPowerUp = Instantiate(powerUpPrefab);
            newPowerUp.GetComponentInChildren<PowerUp>().Activate(startPos, 0);
            powerUps.Add(newPowerUp.GetComponentInChildren<PowerUp>());
        }
    }
}
