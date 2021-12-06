using UnityEngine;

namespace Services
{
    public interface IInventoryScreen : IService
    {
        void InitInventoryScreenFromView(GameObject inventoryLayout, Transform contentHolder);
        void UpdateInventory();
        void UpdateInventoryState();
        void UpdateInventoryState(bool state);
    }
}
