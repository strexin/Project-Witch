using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    [CreateAssetMenu(fileName = "New Default Object", menuName ="Inventory System/Items/Default")]
    public class DefaultObjectSo : ItemObject
    {
        private void Awake()
        {
            itemType = ItemType.Default;
        }
    }
}
