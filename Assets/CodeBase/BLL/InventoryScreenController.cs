using Inventory.Items.PL;
using Player.Inventroy.DAL;
using Player.Inventroy.PL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Inventroy.BLL
{
    public class InventoryScreenController : IInventoryScreen
    {
        private IPlayerInventory playerInventory;
        private IPlayerHealth playerHealth;
        private GameObject inventoryLayout;
        private Transform contentHolder;
        private List<ItemUiContainerView> ItemUiContainerViewList = new List<ItemUiContainerView>();

        public InventoryScreenController(IPlayerInventory playerInventory, IPlayerHealth playerHealth)
        {
            this.playerInventory = playerInventory;
            this.playerHealth = playerHealth;
        }

        public void InitInventoryScreenFromView(GameObject inventoryLayout, Transform contentHolder)
        {
            this.inventoryLayout = inventoryLayout;
            this.contentHolder = contentHolder;
        }

        public void UpdateInventory()
        {
            InventoryData data = AllServices.Container.Single<IPlayerInventory>().GetData();

            foreach (var spawnedItem in ItemUiContainerViewList)
            {
                if (spawnedItem != null)
                {
                    spawnedItem.gameObject.SetActive(false);
                }
            }

            foreach (var item in data.Items)
            {
                ItemUiContainerView itemContainer = default;

                if (!ItemUiContainerViewList.Contains(item.Key.Prefab.GetComponent<ItemUiContainerView>()))
                {
                    itemContainer = GameObject.Instantiate(item.Key.Prefab, contentHolder).GetComponent<ItemUiContainerView>();

                    SetInventoryButtons(item, itemContainer);

                    ItemUiContainerViewList.Add(itemContainer);
                }

                else
                {
                    itemContainer = ItemUiContainerViewList.FirstOrDefault(x => item.Key.Prefab.GetComponent<ItemUiContainerView>());
                }

                itemContainer.gameObject.SetActive(true);
                itemContainer.Amount.text = item.Value.ToString();
            }
        }

        public void UpdateInventoryState()
        {
            inventoryLayout.SetActive(!inventoryLayout.activeSelf);
        }

        public void UpdateInventoryState(bool state)
        {
            inventoryLayout.SetActive(state);
        }

        private void SetInventoryButtons(System.Collections.Generic.KeyValuePair<ItemObject, int> item, ItemUiContainerView itemContainer)
        {
            switch (item.Key)
            {
                case ConsumableItem consumable:
                    itemContainer.GetComponent<Button>().onClick.AddListener(
                    delegate
                    {
                        playerHealth.RestoreHealth(consumable.RestoreHealthAmount, item.Key);
                        UpdateInventory();
                    }
                    );
                    break;
                default:
                    break;
                case null:
                    throw new ArgumentNullException(nameof(item.Key));
            }
        }
    }
}
