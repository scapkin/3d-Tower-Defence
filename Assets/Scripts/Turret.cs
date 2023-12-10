using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Utilities;

public abstract class Turret : MonoBehaviour
{
    public float Range;
    public float Damage;
    public float Cost;
    public float FireRate;
    public GameObject FireEffect;
    public GameObject BulletPrefab;
    public Transform Target;
    public LayerMask EnemyLayer;

    private float _currentTimer;
    protected float _lastAttackTime;
    private Collider[] _colliders;

    private void Update()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= FireRate)
        {
            FindTarget();
            RotateToTarget();
            Shoot();
            _currentTimer = 0;
        }
    }

    public abstract void Shoot();

    private void FindTarget()
    {
        FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        _colliders = Physics.OverlapSphere(transform.position, Range,EnemyLayer);
        if (_colliders.Length == 0)
        {
            Target = null;
            return;
        }
        Target = _colliders.GetLowestFromArray(c=>Vector3.Distance(transform.position, c.transform.position)).transform;
    }

    protected virtual void RotateToTarget()
    {
        transform.DOLookAt(Target.position, 0.5f);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}