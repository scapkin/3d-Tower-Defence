using System;
using Managers;
using UnityEngine;


public class MeleeSoldier : Soldier
{
   
    public override void Shoot()
    {
        TowerManager.OnTowerGetDamage?.Invoke(Damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            State = States.Attack;
            Agent.isStopped = true;
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