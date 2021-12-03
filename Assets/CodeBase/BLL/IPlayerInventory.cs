using Player.Inventroy.DAL;

namespace Services
{
    public interface IPlayerInventory : IService
    {
        void AddItem(ItemObject item, int value);
        void RempveItem(ItemObject item, int value);
        void SortItems();
    }
}
