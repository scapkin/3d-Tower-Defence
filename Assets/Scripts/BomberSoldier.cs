using System;
using Interfaces;
using Managers;
using UnityEngine;

public class BomberSoldier : Soldier
{
    
    
    public override void Shoot()
    {
        TowerManager.OnTowerGetDamage?.Invoke(Damage);
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            Shoot();
            ObjectPool.ObjectPool.Instance.ReturnObjectToPool(gameObject);
        }
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(BulletDamageValues.normalBulletDamage);
        }

        if (other.CompareTag("AreaBullet"))
        {
            TakeDamage(BulletDamageValues.areaBulletDamage);
        }
    }
}