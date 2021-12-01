using UnityEngine;

namespace Services {
    public interface IHealthHud : IService
    {
        void InitHealthbar(Transform healthContainerParent, GameObject prefab);
        void SetHealth();
        void AddHearts();
        void RemoveHearts();
    }
}
