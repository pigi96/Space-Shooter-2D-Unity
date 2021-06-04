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
}