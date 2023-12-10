using System;
using Data;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image levelFillUi;
        [SerializeField] private LevelEnemyValues levelEnemyValues;
        private SaveData _gameData;
        private int _level;
        [SerializeField]private int _totalEnemyCount;
        [SerializeField]private int _currentEnemyCount;
        
        public static Action<int> OnLevelFillUiChanged;
        
        private void Start()
        {
            _gameData = GameDataManager.Instance.Data;
            _level = _gameData.Level;
            _totalEnemyCount = levelEnemyValues.LevelValues[_level].BomberEnemy +
                               levelEnemyValues.LevelValues[_level].RangeEnemy +
                               levelEnemyValues.LevelValues[_level].MeleeEnemy;
            _currentEnemyCount = _totalEnemyCount;
        }
        
        private void OnEnable()
        {
            OnLevelFillUiChanged += UpdateLevelFillUi;
        }
        
        private void OnDisable()
        {
            OnLevelFillUiChanged -= UpdateLevelFillUi;
        }

        private void UpdateLevelFillUi(int value)
        {
            _currentEnemyCount -= value;
            DOTween.To(
                
                () => levelFillUi.fillAmount,
                x => levelFillUi.fillAmount = x,
                _currentEnemyCount / (float) _totalEnemyCount,
                0.5f
            );

        }
    }
}