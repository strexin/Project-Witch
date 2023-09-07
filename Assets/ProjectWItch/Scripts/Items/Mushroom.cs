using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    /// <summary>
    /// Handle the logic for mushroom item.
    /// </summary>
    public class Mushroom : MonoBehaviour, IInteractable
    {
        #region IInteractable

        public void Interact()
        {
            Debug.Log("You interact with mushroom");
        }

        #endregion
    }
}