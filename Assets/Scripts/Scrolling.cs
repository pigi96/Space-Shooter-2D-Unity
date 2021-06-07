using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    float parralax = 2f;

    // Update is called once per frame
    public void UpdatePosition(Transform transform)
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / 200 / parralax;
        offset.y = transform.position.y / 200 / parralax;

        mat.mainTextureOffset = offset;
    }
}
