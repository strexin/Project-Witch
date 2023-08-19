using UnityEngine;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the magic wand stats.
    /// </summary>
    public interface IMagicWand
    {
        /// <summary>
        /// The element that contain in the magic wand.
        /// </summary>
        string SpellElement { get; set; }

        /// <summary>
        /// The prefab of gameobject that will use to spawn the spell.
        /// </summary>
        GameObject SpellPrefab { get; set; }
    }
}