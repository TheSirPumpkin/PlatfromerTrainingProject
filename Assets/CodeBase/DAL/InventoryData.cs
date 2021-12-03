using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Inventroy.DAL
{
    [CreateAssetMenu(fileName = "ItemsData", menuName = "DAL/InventoryData/Inventory")]
    public class InventoryData : ScriptableObject
    {
        public GenericDictionary<ItemObject, int> Items;
    }
}