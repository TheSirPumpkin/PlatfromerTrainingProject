
using UnityEngine;

namespace Player.Inventroy.DAL
{
    [CreateAssetMenu(fileName = "ItemsData", menuName = "DAL/ItemsData/Consumable")]
    public class ConsumableItem : ItemObject
    {
        [Range(0, 5)]
        public int RestoreHealthAmount;
        private void Awake()
        {
            Type = ItemType.Consumable;
        }
    }
}
