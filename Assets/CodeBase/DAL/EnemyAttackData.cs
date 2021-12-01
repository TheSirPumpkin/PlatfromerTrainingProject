using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.DAL
{
    [CreateAssetMenu(fileName = "EnemyAttackData", menuName = "DAL/EnemyAttackData")]
    public class EnemyAttackData : ScriptableObject
    {
        public int SkeletonDamage;
    }
}