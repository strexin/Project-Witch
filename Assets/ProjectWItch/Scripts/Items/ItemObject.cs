using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    public enum ItemType
    {
        Default,
        Food,
        Mushroom,
        Equipment
    }

    public abstract class ItemObject : ScriptableObject
    {
        public GameObject itemPrefab;

        public ItemType itemType;

        [TextArea(15, 20)]
        public string itemDescription;
    }
}