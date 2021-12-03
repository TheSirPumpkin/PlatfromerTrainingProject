using Player.Inventroy.DAL;

namespace Services
{
    public interface IInventoryItem : IService
    {
        void AddItem(ItemObject Item);
    }
}
