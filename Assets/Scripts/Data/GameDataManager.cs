using System.Collections.Generic;
using Singleton;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    public class GameDataManager : Singleton<GameDataManager>
    {
        // Data with json file and load it from there.
        private const string SAVE_FILE_PATH = "savedata.json";

        public SaveData Data;

        private void Awake()
        {
            LoadData();
        }

        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void LoadData()
        {
            FileManager.Load(SAVE_FILE_PATH, (SaveData data) =>
            {
                if (data == null)
                {
                    Data = new SaveData();
                    Data.Level = 1;
                    Data.Gold = 0;
                    Data.TurretsDictionary = new Dictionary<string, int>();
                }
                else
                {
                    Data = data;
                }
            });
        }

        public void IncrementLevel()
        {
            Data.Level++;
        }

        public void AddGold(int amount)
        {
            Data.Gold += amount;
        }

        public void AddTurretLevel(string type)
        {
            int count;
            if (Data.TurretsDictionary.ContainsKey(type))
            {
                Debug.Log("Data doğru geliyor");
            }
            
            if (Data.TurretsDictionary.TryGetValue(type, out count))
            {
                Data.TurretsDictionary[type] = count + 1;
            }
            else
            {
                Data.TurretsDictionary[type] = 1;
            }
        }

        private void SaveData()
        {
            FileManager.Save(SAVE_FILE_PATH, Data);
        }
    }
}