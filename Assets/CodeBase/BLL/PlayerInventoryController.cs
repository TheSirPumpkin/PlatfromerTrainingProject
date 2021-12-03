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

        public void AddItem(ItemObject item, int value)
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
        public void RempveItem(ItemObject item, int value)
        {
            if (inventoryData.Items.ContainsKey(item))
            {
                inventoryData.Items[item] -= value;
                if (inventoryData.Items[item] <= 0)
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