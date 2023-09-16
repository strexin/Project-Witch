using ProjectWItch.Scripts.Items;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName ="Inventory System/Items/Default")]
public class DefaultObjectSO : ItemObject
{
    private void Awake()
    {
        itemType = ItemType.Default;
    }
}
