using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelValues", menuName = "ScriptableObjects/LevelEnemyValues", order = 1)]
    public class LevelEnemyValues : ScriptableObject
    {
        public List<Values> LevelValues;

        [System.Serializable]
        public class Values
        {
            public int EnemyTypeCount = 3;
            public int MeleeEnemy;
            public int RangeEnemy;
            public int BomberEnemy;
        }
    }
}