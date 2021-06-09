using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public GameObject enemy;
    public ParticleSystem particleSystemExplosion;
    public bool alive;
    public bool halfAlive;

    private void Awake()
    {
       
    }

    public IEnumerator ExplosionEffect()
    {
        // ayayay, no comment
        SoundController.instance.Explosion();
        halfAlive = true;
        transform.position = enemy.transform.position;
        enemy.SetActive(false);
        particleSystemExplosion.Play();
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        alive = false;
        halfAlive = false;
    }

    public void Activate(Vector3 spawnPosition)
    {
        gameObject.SetActive(true);
        enemy.SetActive(true);
        halfAlive = false;
        int random = UnityEngine.Random.Range(0, enemy.GetComponent<Enemyship>().sprites.Length);
        particleSystemExplosion.textureSheetAnimation.SetSprite(0, enemy.GetComponent<Enemyship>().sprites[random]);
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = enemy.GetComponent<Enemyship>().sprites[random];
        transform.position = spawnPosition;
        alive = true;
        enemy.GetComponent<Enemyship>().shipStats.Reset();
        enemy.GetComponent<Enemyship>().HPBarObj.sizeDelta = new Vector2((enemy.GetComponent<Enemyship>().shipStats.HP / enemy.GetComponent<Enemyship>().shipStats.maxHP) * 300f, enemy.GetComponent<Enemyship>().HPBarObj.sizeDelta.y);
    }

    public void Deactivate()
    {
        StartCoroutine(ExplosionEffect());
    }
}
