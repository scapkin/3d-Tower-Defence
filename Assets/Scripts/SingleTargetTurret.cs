using DG.Tweening;
using UnityEngine;

public class SingleTargetTurret : Turret
{
    public override void Shoot()
    {
        if (Target == null)
        {
            return;
        }

        if (Time.time - _lastAttackTime < FireRate)
        {
            return;
        }
        _lastAttackTime = Time.time;
        var bullet = ObjectPool.ObjectPool.Instance.GetObjectFromPool("Bullet", transform.position);
        bullet.transform.position = transform.position;
        bullet.transform.DOMove(Target.position, 2f*Time.unscaledTime).SetSpeedBased();
        //     .OnComplete(() =>
        // {
        //     ObjectPool.ObjectPool.Instance.ReturnObjectToPool(bullet);
        // })
    }


    protected override void RotateToTarget()
    {
    }
}