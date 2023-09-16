using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    /// <summary>
    /// Handle the logic for mushroom item.
    /// </summary>
    public class Mushroom : MonoBehaviour, IInteractable
    {
        #region Variable

        /// <summary>
        /// Component that use to store the item that picked up by player.
        /// </summary>
        [SerializeField]
        private InventoryObject inventoryObject = null;

        /// <summary>
        /// Scriptable object that hold data for this item.
        /// </summary>
        [SerializeField]
        private ItemObject item = null;

        #endregion

        #region IInteractable

        public void Interact()
        {
            Debug.Log("You interact with mushroom " + gameObject.name);

            inventoryObject.AddItem(item, 1);

            Destroy(gameObject);
        }

        #endregion
    }
}