using System.Collections;
using UnityEngine;

public class Enemyship : Spaceship
{
    public Enemyship()
    {
        this.bulletType = BulletType.Enemy;
    }
}
