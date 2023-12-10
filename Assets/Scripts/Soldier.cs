using System;
using Interfaces;
using Managers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

public abstract class Soldier : MonoBehaviour,ITakeDamage
{
    public NavMeshAgent Agent;
    public int Health;
    public float Speed;
    public int Damage;
    public float FireRate = 1;
    public BulletDamageValues BulletDamageValues;
    public Transform Target;
    public States State = States.Patrol;

    private float _shootTimer;
    public enum States
    {
        Patrol,
        Attack
    }

    private void Start()
    {
        Target = TowerManager.OnTowerSelected!.Invoke();
        Chase();
        
    }

    private void Update()
    {
        switch (State)
        {
            case States.Patrol:
                break;
            case States.Attack:
                _shootTimer += Time.deltaTime;
                if (_shootTimer > FireRate)
                {
                    Shoot();
                    _shootTimer = 0;
                }
                break;
        }
    }

    public abstract void Shoot();

    protected virtual void Chase()
    {
        Agent.destination = Target.position;
        Agent.speed = Speed;
    }


    

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            ObjectPool.ObjectPool.Instance.ReturnObjectToPool(gameObject);
            UIManager.OnLevelFillUiChanged?.Invoke(1);
        }
    }
}