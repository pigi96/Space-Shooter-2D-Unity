using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public List<PowerUp> powerUps = new List<PowerUp>();

    public void SpawnPowerUp(Vector3 startPos)
    {
        int rando = Random.Range(0, 1);

        bool reusedPowerup = false;
        for (int i = 0; i < powerUps.Count; i++)
        {
            if (!powerUps[i].alive)
            {
                reusedPowerup = true;
                powerUps[i].Activate(startPos, 0);
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

    public void Update()
    {
        
    }
}
