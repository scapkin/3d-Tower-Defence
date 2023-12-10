using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletValues", menuName = "ScriptableObjects/ButtletDamageValues", order = 2)]
    public class BulletDamageValues : ScriptableObject
    {
        public int normalBulletDamage;
        public int areaBulletDamage;
    }
}