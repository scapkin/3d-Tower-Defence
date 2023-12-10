using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ObjectPool.ObjectPool.Instance.ReturnObjectToPool(gameObject);
    }
}