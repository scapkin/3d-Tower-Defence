using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [System.Serializable]
    public class SaveData
    {
        public int Level;
        public int Gold;
        public Dictionary<string, int> TurretsDictionary;
    }

    public class FileManager
    {
        public static void Save<T>(string filePath, T data)
        {
            string jsonData = JsonUtility.ToJson(data);
            File.WriteAllText(filePath, jsonData);
        }

        public static void Load<T>(string filePath, Action<T> callback)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                T data = JsonUtility.FromJson<T>(jsonData);
                callback(data);
            }
            else
            {
                callback(default(T));
            }
        }
    }
}