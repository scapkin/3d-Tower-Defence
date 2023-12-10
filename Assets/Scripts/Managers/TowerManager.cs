using System;
using Interfaces;
using Singleton;
using UnityEngine;

namespace Managers
{
    public class TowerManager : MonoBehaviour,ITakeDamage
    {
        public static Func<Transform> OnTowerSelected;
        public static Action<int> OnTowerGetDamage;
        public int Health;

        private void OnEnable()
        {
            OnTowerSelected += GetTower;
            OnTowerGetDamage += TakeDamage;
        }
        
        private void OnDisable()
        {
            OnTowerSelected -= GetTower;
            OnTowerGetDamage -= TakeDamage;
        }
        
        private Transform GetTower()
        {
            return transform;
        }


        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                //TODO: Game Over
            }
        }
        
    }
}