using UnityEditor;
using UnityEngine;

public class ShipStats
{
    // Base configuation for ships at runtime
    public float maxHP { set; get; }
    public float maxArmor { set; get; }
    public float baseBulletDamage { set; get; }
    public float baseVelocity { set; get; }
    public float baseTorque { set; get; }
    public float speedBuffTime { set; get; }
    public float damageBuffTime { set; get; }

    public ShipStats(ShipStats copyFrom)
    {
        Init(copyFrom.maxHP, copyFrom.maxArmor, copyFrom.baseBulletDamage, copyFrom.baseVelocity, copyFrom.baseTorque, copyFrom.bulletType, copyFrom.speedBuffTime, copyFrom.damageBuffTime);
    }

    public ShipStats(float maxHP, float maxArmor, float baseBulletDamage, float baseVelocity, float baseTorque, BulletType type, float speedBuffTime, float damageBuffTime)
    {
        Init(maxHP, maxArmor, baseBulletDamage, baseVelocity, baseTorque, type, speedBuffTime, damageBuffTime);
    }

    void Init(float maxHP, float maxArmor, float baseBulletDamage, float baseVelocity, float baseTorque, BulletType type, float speedBuffTime, float damageBuffTime)
    {
        this.maxHP = maxHP;
        this.maxArmor = maxArmor;
        this.baseBulletDamage = baseBulletDamage;
        this.baseVelocity = baseVelocity;
        this.baseTorque = baseTorque;
        this.bulletType = type;
        this.speedBuffTime = speedBuffTime;
        this.damageBuffTime = damageBuffTime;
        Reset();
    }

    // InGame life variables
    public float HP { set; get; }
    public float armor { set; get; }
    public float bulletDamage { set; get; }
    public float velocity { set; get; }
    public float torque { set; get; }
    public BulletType bulletType { set; get; }
    public float doubleDamage { set; get; }
    public float doubleSpeed { set; get; }

    public void Reset()
    {
        HP = maxHP;
        armor = 0;
        bulletDamage = baseBulletDamage;
        velocity = baseVelocity;
        torque = baseTorque;
        doubleDamage = 0;
        doubleSpeed = 0;
    }

    public void TakeDamage(float damage)
    {
        armor -= damage;
        if (armor < 0)
        {
            HP += armor;
            armor = 0;

            if (HP < 0)
                HP = 0;
        }
    }

    public void Repair()
    {
        HP = maxHP;
    }

    public void Replenish()
    {
        armor = maxArmor;
    }

    public void DoubleSpeed()
    {
        doubleSpeed = speedBuffTime;
    }

    public void DoubleDamage()
    {
        doubleDamage = damageBuffTime;
    }

    public void Update(float deltaTime)
    {
        doubleSpeed -= deltaTime;
        if (doubleSpeed > 0)
        {
            velocity = 2 * baseVelocity;
            SoundController.instance.engine.pitch = 1.3f;
        } else
        {
            velocity = baseVelocity;
            SoundController.instance.engine.pitch = .65f;
        }

        doubleDamage -= deltaTime;
        if (doubleDamage > 0)
        {
            bulletDamage = 2 * baseBulletDamage;
        } else
        {
            bulletDamage = baseBulletDamage;
        }
    }
}