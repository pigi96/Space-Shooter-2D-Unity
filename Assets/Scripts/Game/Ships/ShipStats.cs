using UnityEditor;
using UnityEngine;

public class ShipStats
{
    public float maxHP { set; get; }
    public float maxArmor { set; get; }
    public float baseBulletDamage { set; get; }
    public float baseVelocity { set; get; }
    public float baseTorque { set; get; }

    public ShipStats(ShipStats copyFrom)
    {
        Init(copyFrom.maxHP, copyFrom.maxArmor, copyFrom.baseBulletDamage, copyFrom.baseVelocity, copyFrom.baseTorque, copyFrom.bulletType);
    }

    public ShipStats(float maxHP, float maxArmor, float baseBulletDamage, float baseVelocity, float baseTorque, BulletType type)
    {
        Init(maxHP, maxArmor, baseBulletDamage, baseVelocity, baseTorque, type);
    }

    void Init(float maxHP, float maxArmor, float baseBulletDamage, float baseVelocity, float baseTorque, BulletType type)
    {
        this.maxHP = maxHP;
        this.maxArmor = maxArmor;
        this.baseBulletDamage = baseBulletDamage;
        this.baseVelocity = baseVelocity;
        this.baseTorque = baseTorque;
        this.bulletType = type;
        Reset();
    }

    public float HP { set; get; }
    public float armor { set; get; }
    public float bulletDamage { set; get; }
    public float velocity { set; get; }
    public float torque { set; get; }
    public BulletType bulletType { set; get; }

    public void Reset()
    {
        HP = maxHP;
        armor = 0;
        bulletDamage = baseBulletDamage;
        velocity = baseVelocity;
        torque = baseTorque;
    }

    /*public void IncreaseBulletDamage(float multiplier)
    {
        bulletDamage *= multiplier;
    }

    public void ResetBulletDamage()
    {
        bulletDamage = baseBulletDamage;
    }*/

    public void TakeDamage(float damage)
    {
        armor -= damage;
        if (armor < 0)
        {
            HP += armor;
            armor = 0;
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
}