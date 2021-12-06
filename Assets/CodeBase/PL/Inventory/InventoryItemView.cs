using Player.Inventroy.DAL;
using Player.Inventroy.PL;
using Services;
using UnityEngine;

namespace Inventory.Items.PL
{
    public abstract class InventoryItemView : MonoBehaviour
    {
        public ItemObject Item;

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerInventoryView>())
            {
                AllServices.Container.Single<IInventoryItem>().AddItem(Item);
                AllServices.Container.Single<IInventoryScreen>().UpdateInventory();
                Destroy(gameObject);
            }
        }
    }
}
