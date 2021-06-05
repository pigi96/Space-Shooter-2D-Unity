using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletType type;

    public bool alive = false;

    public float currentDistance = 0;

    public void Deactivate()
    {
        alive = false;
        currentDistance = 0;
        gameObject.SetActive(false);
    }

    public void Activate(Transform startPos, BulletType type)
    {
        alive = true;
        this.type = type;
        gameObject.SetActive(true);
        this.type = type;
        transform.position = startPos.transform.position;
        transform.rotation = startPos.transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (type == BulletType.Enemy && other.CompareTag("Enemy"))
        {
            return;
        }

        if (type == BulletType.Player && other.CompareTag("Player"))
        {
            return;
        }

        Deactivate();
    }
}