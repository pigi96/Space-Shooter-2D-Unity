using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playership : Spaceship
{
    public Playership()
    {
        this.bulletType = BulletType.Player;
        this.MAX_HP = 10000;
        this.HP = 10000;
    }
}
