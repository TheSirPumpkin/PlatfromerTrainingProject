using UnityEngine;

namespace Player.Inventroy.DAL
{
    public class ItemObject : ScriptableObject
    {
        public GameObject Prefab;
        public ItemType Type;
        [TextArea(15, 20)]
        public string Description;
        [Range(1, 100)]
        public int Amount;
    }
}
