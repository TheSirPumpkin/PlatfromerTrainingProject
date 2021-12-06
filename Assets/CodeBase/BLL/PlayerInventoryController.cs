using Player.Inventroy.DAL;
using Services;
using System.Linq;
using UnityEngine;

namespace Player.Inventroy.BLL
{
    public class PlayerInventoryController : IPlayerInventory
    {
        private InventoryData inventoryData;

        public PlayerInventoryController()
        {
            this.inventoryData = ScriptableObjectsContainer.Instance.PlayerInventoryData; // Resources.Load<InventoryData>(PathConstants.PlayerInventoryPath); 
        }
        public InventoryData GetData()
        {
            return inventoryData;
        }
        public void AddItem(ItemObject item, int value = 1)
        {
            if (inventoryData.Items.ContainsKey(item))
            {
                inventoryData.Items[item] += value;
            }
            else
            {
                inventoryData.Items.Add(item, value);
            }
        }
        public void RemoveItem(ItemObject item, int amount)
        {
            if (inventoryData.Items.ContainsKey(item))
            {
                if (inventoryData.Items[item] >= amount)
                {
                    inventoryData.Items[item] -= amount;
                }

                if (inventoryData.Items[item] < amount)
                {
                    inventoryData.Items.Remove(item);
                }
            }
        }
        public void SortItems()
        {
            inventoryData.Items.OrderBy(item => item.Value);
        }
    }
}