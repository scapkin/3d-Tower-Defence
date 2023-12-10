using System;
using UnityEngine;

namespace ObjectPool
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject prefab;
        public String type;
        public int initialPoolSize;
    }
}