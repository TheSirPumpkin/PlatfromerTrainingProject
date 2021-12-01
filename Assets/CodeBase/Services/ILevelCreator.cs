using System.Collections;
using UnityEngine;

namespace Services
{
    public interface ILevelCreator : IService
    {
        void CreateLevel(MonoBehaviour view);
        IEnumerator SpawnPlayer();
        IEnumerator SpawnEnemy(Vector2 spawnPos, string name);
    }
}