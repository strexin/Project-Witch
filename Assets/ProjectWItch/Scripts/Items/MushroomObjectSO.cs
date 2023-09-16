using ProjectWItch.Scripts.Items;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mushroom Object", menuName = "Inventory System/Items/Mushrooms")]
public class MushroomObjectSO : ItemObject
{
    private void Awake()
    {
        itemType = ItemType.Mushroom;
    }
}
