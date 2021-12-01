using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.DAL
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "DAL/LevelsData")]
    public class LevelsData : ScriptableObject
    {
        public int LevelToLoad;
        public Vector2 PlayerStartPosition;
        public GenericDictionary<Vector2, string> Enemies;
    }
} 
