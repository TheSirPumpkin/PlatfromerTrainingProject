using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.DAL
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "DAL/AttackData")]
    public class AttackDetectionData : ScriptableObject
    {
        public float Damage;
    }
}
