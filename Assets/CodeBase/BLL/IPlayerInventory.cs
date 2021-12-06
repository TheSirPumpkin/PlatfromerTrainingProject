using Player.Inventroy.DAL;

namespace Services
{
    public interface IPlayerInventory : IService
    {
        InventoryData GetData();
        void AddItem(ItemObject item, int value);
        void RemoveItem(ItemObject item, int amount = 1);
        void SortItems();
    }
}
