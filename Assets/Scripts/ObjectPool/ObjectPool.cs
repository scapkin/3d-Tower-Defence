using System.Collections.Generic;
using DG.Tweening;
using Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObjectPool
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        [SerializeField] private List<ObjectPoolItem> objectPoolItems;
        private Dictionary<GameObject, Queue<GameObject>> _objectPoolDictionary;
        private Dictionary<string,GameObject> _typeToPrefabDictionary;

        private void Awake()
        {
            InitializeObjectPools();
            DontDestroyOnLoad(this.gameObject);
            DOVirtual.DelayedCall(2f, () => { SceneManager.LoadScene(1); });
        }

        private void InitializeObjectPools()
        {
            _objectPoolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
            _typeToPrefabDictionary = new Dictionary<string, GameObject>();
            foreach (var item in objectPoolItems)
            {
                GameObject prefab = item.prefab;
                int initialPoolSize = item.initialPoolSize;
                _typeToPrefabDictionary.Add(item.type,prefab);
                
                if (!_objectPoolDictionary.ContainsKey(prefab))
                {
                    Queue<GameObject> objectPool = new Queue<GameObject>();

                    for (int i = 0; i < initialPoolSize; i++)
                    {
                        GameObject obj = Instantiate(prefab);
                        obj.name = prefab.name;
                        obj.transform.parent = this.transform;
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }

                    _objectPoolDictionary.Add(prefab, objectPool);
                }
            }
        }

        private Queue<GameObject> _objectPool;
        private GameObject _obj;

        public GameObject GetObjectFromPool(string Type, Vector3 pos)
        {
            if (_typeToPrefabDictionary.ContainsKey(Type))
            {
                _obj = _typeToPrefabDictionary[Type].gameObject;
            }
            else
            {
                Debug.LogWarning($"Object pool for object {_obj.name} does not exist!");
                return null;
            }

            if (_objectPoolDictionary.ContainsKey(_obj))
            {
                _objectPool = _objectPoolDictionary[_obj];

                if (_objectPool.Count > 0)
                {
                    _obj = _objectPool.Dequeue();
                }
                else
                {
                    _obj = Instantiate(_obj);
                }

                _obj.transform.position = pos;
                _obj.SetActive(true);
                return _obj;
            }
            else
            {
                Debug.LogWarning($"Object pool for object {_obj.name} does not exist!");
                return null;
            }
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            obj.SetActive(false);
            foreach (var kvp in _objectPoolDictionary)
            {
                if (kvp.Key.name == obj.name)
                {
                    //Debug.Log(obj);
                    kvp.Value.Enqueue(obj);
                    return;
                }
            }

            Debug.LogWarning($"Object pool for object {obj.name} does not exist!");
        }
    }
}