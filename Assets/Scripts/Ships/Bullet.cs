using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool alive = false;

    public float currentDistance = 0;

    public void Deactivate()
    {
        alive = false;
        currentDistance = 0;
        gameObject.SetActive(false);
    }

    public void Activate(Transform startPos)
    {
        alive = true;
        gameObject.SetActive(true);
        transform.position = startPos.transform.position;
        transform.rotation = startPos.transform.rotation;
    }
}