using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Playership playershipScr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
        ControlEnemies();
    }


    void ControlPlayer()
    {
        playershipScr.Move(PlayerMoveInput());
        playershipScr.Rotate(PlayerRotateInput());
        playershipScr.Shoot(PlayerHasShot());
        transform.position = new Vector3(playershipScr.transform.position.x, playershipScr.transform.position.y, -10);
    }

    void ControlEnemies()
    {

    }


    public bool PlayerMoveInput()
    {
        return Input.GetKey(KeyCode.UpArrow) ? true : false;
    }

    public Direction PlayerRotateInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return Direction.Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return Direction.Right;
        }
        return Direction.None;
    }

    public bool PlayerHasShot()
    {
        return Input.GetKeyDown(KeyCode.Space) ? true : false;
    }
}
