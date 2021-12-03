using Player.Inventroy.DAL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class InventoryItemController : IInventoryItem
    {
        private IPlayerInventory playerInventory;

        public InventoryItemController(IPlayerInventory playerInventory)
        {
            this.playerInventory = playerInventory;
        }

        public void AddItem(ItemObject Item)
        {
            AllServices.Container.Single<IPlayerInventory>().AddItem(Item, Item.Amount);
        }
    }
}
