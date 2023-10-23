using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    [CreateAssetMenu(fileName = "New Mushroom Object", menuName = "Inventory System/Items/Mushrooms")]
    public class MushroomObjectSo : ItemObject
    {
        private void Awake()
        {
            itemType = ItemType.Mushroom;
        }
    }
}
