using System;
using Data;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;
using Sequence = DG.Tweening.Sequence;

public class Spawner : MonoBehaviour
{
    public LevelEnemyValues LevelEnemyValues;


    private SaveData _gameData;
    private ObjectPool.ObjectPool _objectPool;
    private int _level;
    private int _random;
    Sequence _sequence;

    private void Start()
    {
        _gameData = GameDataManager.Instance.Data;
        _level = _gameData.Level;
        _objectPool = ObjectPool.ObjectPool.Instance;
        _bomberCount = LevelEnemyValues.LevelValues[_level].BomberEnemy;
        _rangeCount = LevelEnemyValues.LevelValues[_level].RangeEnemy;
        _meleeCount = LevelEnemyValues.LevelValues[_level].MeleeEnemy;
        Spawn();
    }


    private Tween _callback;
    private int _bomberCount;
    private int _rangeCount;
    private int _meleeCount;

    public void Spawn()
    {
        GetRandomEnemies();
        _sequence = DOTween.Sequence().SetDelay(1f).AppendCallback(() => { Spawn(); }).OnComplete(() =>
        {
            if (_bomberCount + _rangeCount + _meleeCount == 0)
            {
                _sequence.Kill();
            }
        });
    }

    private void GetRandomEnemies()
    {
        _random = Random.Range(0, LevelEnemyValues.LevelValues[_level].EnemyTypeCount);
        switch (_random)
        {
            case 0:
                if (_bomberCount == 0) break;
                _objectPool.GetObjectFromPool("BomberEnemy", transform.position);
                _bomberCount--;
                break;
            case 1:
                if (_rangeCount == 0) break;
                _objectPool.GetObjectFromPool("RangeEnemy", transform.position);
                _rangeCount--;
                break;
            case 2:
                if (_meleeCount == 0) break;
                _objectPool.GetObjectFromPool("MeleeEnemy", transform.position);
                _meleeCount--;
                break;
        }
    }
    
}