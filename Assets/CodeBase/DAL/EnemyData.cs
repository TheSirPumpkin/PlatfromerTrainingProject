using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.DAL
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "DAL/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float Hp;
        public float AttackDistance;
        public float Speed;
        public float RecpveryTime;
        public float AmbientEnableMin;
        public float AmbientEnableMax;
    }
}
