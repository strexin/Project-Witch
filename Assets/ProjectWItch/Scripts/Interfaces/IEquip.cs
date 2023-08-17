using UnityEngine;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the item that is equipped by an object.
    /// </summary>
    public interface IEquip
    {
        /// <summary>
        /// Max slot for the item that can use.
        /// </summary>
        int ItemSlot { get; set; }

        /// <summary>
        /// Items that store in slots as gameobject.
        /// </summary>
        GameObject[] ItemsGameobject { get; set; }

        /// <summary>
        /// Item that is equipped by this object.
        /// </summary>
        GameObject ItemEquipped { get; set; }
    }
}