using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlayfield : MonoBehaviour
{
    float width = 1000;
    float height = 1000;

    public GameObject playfieldObject;
    public GameObject starPefab;

    // Start is called before the first frame update
    void Start()
    {
        playfieldObject.GetComponent<Transform>().localScale = new Vector3(width, height, 0);
        CreateBackgroundStars();
    }



    void CreateBackgroundStars()
    {
        for (int i = 5; i < width; i += 30)
        {
            for (int j = 5; j < height; j += 30)
            {
                bool skip = Random.Range(0, 3) == 0 ? false : true;
                if (skip) continue;

                GameObject newStar = Instantiate(starPefab);
                newStar.transform.parent = playfieldObject.transform;

                float x = -width / 2 + i + Random.Range(0, 9);
                float y = -height / 2 + j + Random.Range(0, 9);

                newStar.transform.position = new Vector3(x, y, 1);

                float size = Random.Range(0, 30);
                newStar.transform.localScale = new Vector3(0.0006f + (0.00005f*size), 0.0006f + (0.00005f*size), 0);
            }
        }
    }
}
